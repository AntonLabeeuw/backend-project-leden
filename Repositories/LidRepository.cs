namespace Leden.API.Repositories;

public interface ILidRepository
{
    Task<Lid> AddLid(Lid newLid);
    Task<List<Lid>> GetAllLeden();
    Task<List<Lid>> GetLedenByGroepId(string GroepId);
    Task<List<Lid>> GetLedenByTakId(string TakId);
    Task<Lid> GetLid(string id);
}

public class LidRepository : ILidRepository
{
    private readonly IMongoContext _context;

    public LidRepository(IMongoContext context)
    {
        _context = context;
    }

    public async Task<List<Lid>> GetAllLeden() => await _context.LidCollection.Find(_ => true).ToListAsync();

    public async Task<Lid> GetLid(string id) => await _context.LidCollection.Find(l => l.LidId == id).FirstOrDefaultAsync();

    public async Task<List<Lid>> GetLedenByTakId(string TakId) => await _context.LidCollection.Find(l => l.Tak.TakId == TakId).ToListAsync();

    public async Task<List<Lid>> GetLedenByGroepId(string groepId) => await _context.LidCollection.Find(l => l.Groep.GroepId == groepId).ToListAsync();

    public async Task<Lid> AddLid(Lid newLid)
    {
        await _context.LidCollection.InsertOneAsync(newLid);
        return newLid;
    }
}