namespace Leden.API.Repositories;

public interface IGroepRepository
{
    Task<Groep> AddGroep(Groep newGroep);
    Task<List<Groep>> GetAllGroepen();
    Task<Groep> GetGroep(Guid id);
}

public class GroepRepository : IGroepRepository
{
    private readonly IMongoContext _context;

    public GroepRepository(IMongoContext context)
    {
        _context = context;
    }

    public async Task<List<Groep>> GetAllGroepen() => await _context.GroepCollection.Find(_ => true).ToListAsync();

    public async Task<Groep> GetGroep(Guid id) => await _context.GroepCollection.Find(g => g.GroepId == id).FirstOrDefaultAsync();

    public async Task<Groep> AddGroep(Groep newGroep)
    {
        await _context.GroepCollection.InsertOneAsync(newGroep);
        return newGroep;
    }
}