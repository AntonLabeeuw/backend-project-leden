namespace Leden.API.Repositories;

public interface ILidRepository
{
    Task<Lid> AddLid(Lid newLid);
    Task<List<Lid>> GetAllLeden();
    Task<List<Lid>> GetLedenByGroepId(Guid GroepId);
    Task<List<Lid>> GetLedenByTakId(Guid TakId);
    Task<Lid> GetLid(Guid id);
}

public class LidRepository : ILidRepository
{
    private readonly IMongoContext _context;

    public LidRepository(IMongoContext context)
    {
        _context = context;
    }

    public async Task<List<Lid>> GetAllLeden() => await _context.LidCollection.Find(_ => true).ToListAsync();

    public async Task<Lid> GetLid(Guid id) => await _context.LidCollection.Find(l => l.LidId == id).FirstOrDefaultAsync();

    public async Task<List<Lid>> GetLedenByTakId(Guid TakId) => await _context.LidCollection.Find(l => l.Tak.TakId == TakId).ToListAsync();

    public async Task<List<Lid>> GetLedenByGroepId(Guid GroepId) => await _context.LidCollection.Find(l => l.Groep.GroepId == GroepId).ToListAsync();

    public async Task<Lid> AddLid(Lid newLid)
    {
        await _context.LidCollection.InsertOneAsync(newLid);
        return newLid;
    }
}