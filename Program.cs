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

app.MapGet("/leden", (ILidService LidService) => LidService.GetAllLeden());

app.MapGet("/lid/{lidId}", (ILidService LidService, string lidId) => LidService.GetLid(lidId));

app.MapGet("/leden/tak/{takId}", (ILidService LidService, string takId) => LidService.GetLedenByTakId(takId));

app.MapGet("/leden/groep/{groepId}", (ILidService LidService, string groepId) => LidService.GetLedenByGroepId(groepId));

app.MapGet("/takken", (ILidService LidService) => LidService.GetAllTakken());

app.MapGet("/tak/{takId}", (ILidService LidService, string takId) => LidService.GetTak(takId));

app.MapGet("/groepen", (ILidService LidService) => LidService.GetAllGroepen());

app.MapGet("/groep/{groepId}", (ILidService LidService, string groepId) => LidService.GetGroep(groepId));

// POST

app.MapPost("/lid", async (ILidService LidService, Lid lid) => {
    var result = await LidService.AddLid(lid);
    return Results.Created("", result);
});

app.MapPost("/tak", async (ILidService LidService, Tak tak) => {
    var result = await LidService.AddTak(tak);
    return Results.Created($"/takken/{tak.TakId}", result);
});

app.MapPost("/groep", async (ILidService LidService, Groep groep) => {
    var result = await LidService.AddGroep(groep);
    return Results.Created("", result);
});


app.Run("http://0.0.0.0:3000");
