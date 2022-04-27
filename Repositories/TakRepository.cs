namespace Leden.API.Repositories;

public interface ITakRepository
{
    Task<Tak> AddTak(Tak newTak);
    Task<List<Tak>> GetAllTakken();
    Task<Tak> GetTak(string id);
    Task<Tak> UpdateTak(Tak tak);
}

public class TakRepository : ITakRepository
{
    private readonly IMongoContext _context;

    public TakRepository(IMongoContext context)
    {
        _context = context;
    }

    public async Task<List<Tak>> GetAllTakken() => await _context.TakCollection.Find(_ => true).ToListAsync();

    public async Task<Tak> GetTak(string id) => await _context.TakCollection.Find(t => t.TakId == id).FirstOrDefaultAsync();

    public async Task<Tak> AddTak(Tak newTak)
    {
        try {
            await _context.TakCollection.InsertOneAsync(newTak);
            return newTak;
        }
        catch (Exception ex){
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<Tak> UpdateTak(Tak tak)
    {
        var filter = Builders<Tak>.Filter.Eq("TakId", tak.TakId);
        var update = Builders<Tak>.Update.Set("TakNaam", tak.TakNaam);
        var result = await _context.TakCollection.UpdateOneAsync(filter, update);
        return await GetTak(tak.TakId);
    }
}