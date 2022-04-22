namespace Leden.API.Context;

public class MongoContext
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    private readonly DatabaseSettings _settings;

    public IMongoClient Client
    {
        get
        {
            return _client;
        }
    }

    public IMongoDatabase Database => _database;

    public MongoContext(IOptions<DatabaseSettings> dbOptions)
    {
        _settings = dbOptions.Value;
        _client = new MongoClient(_settings.ConnectionString);
        _database = _client.GetDatabase(_settings.DatabaseName);
    }

    public IMongoCollection<Lid> LidCollection
    {
        get
        {
            return _database.GetCollection<Lid>(_settings.LidCollection);
        }
    }

    public IMongoCollection<Tak> TakCollection
    {
        get
        {
            return _database.GetCollection<Tak>(_settings.TakCollection);
        }
    }

    public IMongoCollection<Groep> GroepCollection
    {
        get
        {
            return _database.GetCollection<Groep>(_settings.GroepCollection);
        }
    }
}