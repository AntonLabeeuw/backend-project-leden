namespace Leden.API.Repositories;

public interface IGroepRepository
{
    Task<Groep> AddGroep(Groep newGroep);
    Task DeleteGroep(string groepId);
    Task<List<Groep>> GetAllGroepen();
    Task<Groep> GetGroep(string id);
    Task<Groep> UpdateGroep(string groepId, Groep groep);
}

public class GroepRepository : IGroepRepository
{
    private readonly IMongoContext _context;

    public GroepRepository(IMongoContext context)
    {
        _context = context;
    }

    public async Task<List<Groep>> GetAllGroepen() => await _context.GroepCollection.Find(_ => true).ToListAsync();

    public async Task<Groep> GetGroep(string id) => await _context.GroepCollection.Find(g => g.GroepId == id).FirstOrDefaultAsync();

    public async Task<Groep> AddGroep(Groep newGroep)
    {
        try
        {
            await _context.GroepCollection.InsertOneAsync(newGroep);
            return newGroep;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

    }

    public async Task<Groep> UpdateGroep(string groepId, Groep groep)
    {
        var filter = Builders<Groep>.Filter.Eq(g => g.GroepId, groepId);
        var update = Builders<Groep>.Update
            .Set(g => g.GroepNaam, groep.GroepNaam)
            .Set(g => g.Site, groep.Site)
            .Set(g => g.Email, groep.Email)
            .Set(g => g.Oprichtingsdatum, groep.Oprichtingsdatum)
            .Set(g => g.Rekeningnummer, groep.Rekeningnummer)
            .Set(g => g.Adres, groep.Adres)
            .Set(g => g.Postcode, groep.Postcode)
            .Set(g => g.Gemeente, groep.Gemeente)
            .Set(g => g.Groepsleider1, groep.Groepsleider1)
            .Set(g => g.Groepsleider2, groep.Groepsleider2)
            .Set(g => g.Secretaris, groep.Secretaris)
            .Set(g => g.Penningmeester, groep.Penningmeester);
        await _context.GroepCollection.UpdateOneAsync(filter, update);
        return await GetGroep(groepId);
    }

    public async Task DeleteGroep(string groepId) => await _context.GroepCollection.DeleteOneAsync(t => t.GroepId == groepId);
}