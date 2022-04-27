var builder = WebApplication.CreateBuilder(args);
var mongoSettings = builder.Configuration.GetSection("MongoConnection");
builder.Services.Configure<DatabaseSettings>(mongoSettings);
builder.Services.AddTransient<IMongoContext, MongoContext>();

builder.Services.AddTransient<ILidRepository, LidRepository>();
builder.Services.AddTransient<ITakRepository, TakRepository>();
builder.Services.AddTransient<IGroepRepository, GroepRepository>();
builder.Services.AddTransient<ILidService, LidService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// GET

app.MapGet("/leden", (ILidService lidService) => lidService.GetAllLeden());

app.MapGet("/lid/{lidId}", (ILidService lidService, string lidId) => lidService.GetLid(lidId));

app.MapGet("/leden/tak/{takId}", (ILidService lidService, string takId) => lidService.GetLedenByTakId(takId));

app.MapGet("/leden/groep/{groepId}", (ILidService lidService, string groepId) => lidService.GetLedenByGroepId(groepId));

app.MapGet("/takken", (ILidService lidService) => lidService.GetAllTakken());

app.MapGet("/tak/{takId}", (ILidService lidService, string takId) => lidService.GetTak(takId));

app.MapGet("/groepen", (ILidService lidService) => lidService.GetAllGroepen());

app.MapGet("/groep/{groepId}", (ILidService lidService, string groepId) => lidService.GetGroep(groepId));

// POST

app.MapPost("/lid", async (ILidService lidService, Lid lid) => {
    var result = await lidService.AddLid(lid);
    return Results.Created("", result);
});

app.MapPost("/tak", async (ILidService lidService, Tak tak) => {
    var result = await lidService.AddTak(tak);
    return Results.Created($"/takken/{tak.TakId}", result);
});

app.MapPost("/groep", async (ILidService lidService, Groep groep) => {
    var result = await lidService.AddGroep(groep);
    return Results.Created("", result);
});

// PUT

app.MapPut("/lid/{lidId}", async (ILidService lidService, string lidId, Lid lid) => await lidService.UpdateLid(lidId, lid));

app.MapPut("/tak/{takId}", async (ILidService lidService, string takId, Tak tak) => await lidService.UpdateTak(takId, tak));

app.MapPut("/groep/{groepId}", async (ILidService lidService, string groepId, Groep groep) => await lidService.UpdateGroep(groepId, groep));


app.Run("http://0.0.0.0:3000");
