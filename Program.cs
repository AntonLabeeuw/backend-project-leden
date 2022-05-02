var builder = WebApplication.CreateBuilder(args);

var mongoSettings = builder.Configuration.GetSection("MongoConnection");
builder.Services.Configure<DatabaseSettings>(mongoSettings);

var authSettings = builder.Configuration.GetSection("AuthenticationSettings");
builder.Services.Configure<AuthenticationSettings>(authSettings);

builder.Services.AddTransient<IMongoContext, MongoContext>();
builder.Services.AddTransient<ILidRepository, LidRepository>();
builder.Services.AddTransient<ITakRepository, TakRepository>();
builder.Services.AddTransient<IGroepRepository, GroepRepository>();
builder.Services.AddTransient<ILidService, LidService>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LidValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TakValidator>());
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GroepValidator>());

builder.Services.AddAuthorization(options => { });

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options => {
    options.TokenValidationParameters = new (){
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["AuthenticationSettings:Issuer"],
        ValidAudience = builder.Configuration["AuthenticationSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(builder.Configuration["AuthenticationSettings:SecretForKey"]))
    };
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Queries>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .AddMutationType<Mutation>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapSwagger();
app.UseSwaggerUI();

app.MapGraphQL();

app.UseAuthentication();
app.UseAuthorization();

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

// AUTHENTICATION

app.MapPost("/authenticate", (IAuthenticationService authenticationService, AuthenticationRequestBody authenticationRequestBody) => {
    var resp = authenticationService.Authenticate(authenticationRequestBody);

    if (resp is null){
        return Results.Unauthorized();
    } else {
        return Results.Ok(resp);
    }
});

//link naar swagger:
// http://localhost:3000/Swagger/index.html?UjXn2r5u8x/A?D(G+KbPeSgVkYp3s6v9

app.Run("http://0.0.0.0:3000");
// app.Run();

public partial class Program { };


