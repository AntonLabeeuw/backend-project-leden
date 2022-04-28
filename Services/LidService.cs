namespace Leden.API.Services;

public interface ILidService
{
    Task<Groep> AddGroep(Groep newGroep);
    Task<Lid> AddLid(Lid newLid);
    Task<Tak> AddTak(Tak newTak);
    Task DeleteGroep(string groepId);
    Task DeleteLid(string lidId);
    Task DeleteTak(string takId);
    Task<List<Groep>> GetAllGroepen();
    Task<List<Lid>> GetAllLeden();
    Task<List<Tak>> GetAllTakken();
    Task<Groep> GetGroep(string id);
    Task<List<Lid>> GetLedenByGroepId(string GroepId);
    Task<List<Lid>> GetLedenByTakId(string TakId);
    Task<Lid> GetLid(string id);
    Task<Tak> GetTak(string id);
    Task<Groep> UpdateGroep(string groepId, Groep groep);
    Task<Lid> UpdateLid(string lidId, Lid lid);
    Task<Tak> UpdateTak(string takId, Tak tak);
}

public class LidService : ILidService
{
    public readonly ILidRepository _lidRepository;
    public readonly ITakRepository _takRepository;
    public readonly IGroepRepository _groepRepository;

    public LidService(ILidRepository lidRepository, ITakRepository takRepository, IGroepRepository groepRepository)
    {
        _lidRepository = lidRepository;
        _takRepository = takRepository;
        _groepRepository = groepRepository;
    }

    public async Task<List<Lid>> GetAllLeden() => await _lidRepository.GetAllLeden();

    public async Task<Lid> GetLid(string id) => await _lidRepository.GetLid(id);

    public async Task<List<Lid>> GetLedenByTakId(string TakId) => await _lidRepository.GetLedenByTakId(TakId);

    public async Task<List<Lid>> GetLedenByGroepId(string GroepId) => await _lidRepository.GetLedenByGroepId(GroepId);

    public async Task<Lid> AddLid(Lid newLid) => await _lidRepository.AddLid(newLid);

    public async Task<List<Tak>> GetAllTakken() => await _takRepository.GetAllTakken();

    public async Task<Tak> GetTak(string id) => await _takRepository.GetTak(id);

    public async Task<Tak> AddTak(Tak newTak) => await _takRepository.AddTak(newTak);

    public async Task<List<Groep>> GetAllGroepen() => await _groepRepository.GetAllGroepen();

    public async Task<Groep> GetGroep(string id) => await _groepRepository.GetGroep(id);

    public async Task<Groep> AddGroep(Groep newGroep) => await _groepRepository.AddGroep(newGroep);

    public async Task<Lid> UpdateLid(string lidId, Lid lid) => await _lidRepository.UpdateLid(lidId, lid);

    public async Task<Tak> UpdateTak(string takId, Tak tak) => await _takRepository.UpdateTak(takId, tak);

    public async Task<Groep> UpdateGroep(string groepId, Groep groep) => await _groepRepository.UpdateGroep(groepId, groep);

    public async Task DeleteLid(string lidId) => await _lidRepository.DeleteLid(lidId);

    public async Task DeleteTak(string takId) => await _takRepository.DeleteTak(takId);

    public async Task DeleteGroep(string groepId) => await _groepRepository.DeleteGroep(groepId);
}