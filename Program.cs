var builder = WebApplication.CreateBuilder(args);
var mongoSettings = builder.Configuration.GetSection("MongoConnection");
builder.Services.Configure<DatabaseSettings>(mongoSettings);
builder.Services.AddTransient<IMongoContext, MongoContext>();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LidValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TakValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GroepValidator>());
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Queries>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .AddMutationType<Mutation>();

builder.Services.AddTransient<ILidRepository, LidRepository>();
builder.Services.AddTransient<ITakRepository, TakRepository>();
builder.Services.AddTransient<IGroepRepository, GroepRepository>();
builder.Services.AddTransient<ILidService, LidService>();

var app = builder.Build();
app.MapGraphQL();

app.MapGet("/", () => "Hello World!");

// GET

app.MapGet("/leden", async (ILidService lidService) => await lidService.GetAllLeden());

app.MapGet("/lid/{lidId}", async (ILidService lidService, string lidId) => await lidService.GetLid(lidId));

app.MapGet("/leden/tak/{takId}", async (ILidService lidService, string takId) => await lidService.GetLedenByTakId(takId));

app.MapGet("/leden/groep/{groepId}", async (ILidService lidService, string groepId) => await lidService.GetLedenByGroepId(groepId));

app.MapGet("/takken", async (ILidService lidService) => await lidService.GetAllTakken());

app.MapGet("/tak/{takId}", async (ILidService lidService, string takId) => await lidService.GetTak(takId));

app.MapGet("/groepen", async (ILidService lidService) => await lidService.GetAllGroepen());

app.MapGet("/groep/{groepId}", async (ILidService lidService, string groepId) => await lidService.GetGroep(groepId));

// POST

app.MapPost("/lid", async (ILidService lidService, IValidator<Lid> validator, Lid lid) => {
    var validatorResult = validator.Validate(lid);
    if (validatorResult.IsValid){
        var result = await lidService.AddLid(lid);
        return Results.Created("", result);
    } else{
        var errors = validatorResult.Errors.Select(x => new { errors = x.ErrorMessage });
        return Results.BadRequest(errors);
    }
});

app.MapPost("/tak", async (ILidService lidService, IValidator<Tak> validator, Tak tak) => {
    var validatorResult = validator.Validate(tak);
    if (validatorResult.IsValid){
        var result = await lidService.AddTak(tak);
        return Results.Created($"/takken/{tak.TakId}", result);
    } else {
        var errors = validatorResult.Errors.Select(x => new { errors = x.ErrorMessage });
        return Results.BadRequest(errors);
    }
});

app.MapPost("/groep", async (ILidService lidService, IValidator<Groep> validator, Groep groep) => {
    var validatorResult = validator.Validate(groep);
    if (validatorResult.IsValid){
        var result = await lidService.AddGroep(groep);
        return Results.Created("", result);
    } else {
        var errors = validatorResult.Errors.Select(x => new { errors = x.ErrorMessage });
        return Results.BadRequest(errors);
    }

});

// PUT

app.MapPut("/lid/{lidId}", async (ILidService lidService, string lidId, Lid lid) => await lidService.UpdateLid(lidId, lid));

app.MapPut("/tak/{takId}", async (ILidService lidService, string takId, Tak tak) => await lidService.UpdateTak(takId, tak));

app.MapPut("/groep/{groepId}", async (ILidService lidService, string groepId, Groep groep) => await lidService.UpdateGroep(groepId, groep));

// DELETE

app.MapDelete("/lid/{lidId}", async (ILidService lidService, string lidId) => await lidService.DeleteLid(lidId));

app.MapDelete("/tak/{takId}", async (ILidService lidService, string takId) => await lidService.DeleteLid(takId));

app.MapDelete("/groep/{groepId}", async (ILidService lidService, string groepId) => await lidService.DeleteLid(groepId));


app.Run("http://0.0.0.0:3000");
