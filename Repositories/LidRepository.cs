namespace Leden.API.Repositories;

public interface ILidRepository
{
    Task<Lid> AddLid(Lid newLid);
    Task DeleteLid(string lidId);
    Task<List<Lid>> GetAllLeden();
    Task<List<Lid>> GetLedenByGroepId(string groepId);
    Task<List<Lid>> GetLedenByTakId(string TakId);
    Task<Lid> GetLid(string id);
    Task<Lid> UpdateLid(string lidId, Lid lid);
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

    public async Task<Lid> UpdateLid(string lidId, Lid lid)
    {
        var filter = Builders<Lid>.Filter.Eq(l => l.LidId, lidId);
        var update = Builders<Lid>.Update
            .Set(l => l.Naam, lid.Naam)
            .Set(l => l.Voornaam, lid.Voornaam)
            // .Set(l => l.Naam, lid.Naam)
            // .Set(l => l.Naam, lid.Naam)
            .Set(l => l.Adres1, lid.Adres1)
            .Set(l => l.Adres2, lid.Adres2)
            .Set(l => l.Email, lid.Email)
            .Set(l => l.Telefoon, lid.Telefoon)
            .Set(l => l.Gsm, lid.Gsm)
            .Set(l => l.Geboortedatum, lid.Geboortedatum)
            .Set(l => l.Geslacht, lid.Geslacht)
            .Set(l => l.Beperking, lid.Beperking)
            .Set(l => l.VerminderdLidgeld, lid.VerminderdLidgeld);
        await _context.LidCollection.UpdateOneAsync(filter, update);
        return await GetLid(lidId);
    }

    public async Task DeleteLid(string lidId) => await _context.LidCollection.DeleteOneAsync(l => l.LidId == lidId);
}