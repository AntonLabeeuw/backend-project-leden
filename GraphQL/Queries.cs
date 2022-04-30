namespace Leden.API.GraphQL;

public class Queries {
    public async Task<List<Lid>> GetLeden([Service] ILidService lidService) => await lidService.GetAllLeden();

    public async Task<Lid> GetLid([Service] ILidService lidService, string LidId) => await lidService.GetLid(LidId);

    public async Task<List<Lid>> GetLedenByTakId([Service] ILidService lidService, string TakId) => await lidService.GetLedenByTakId(TakId);

    public async Task<List<Lid>> GetLedenByGroepId([Service] ILidService lidService, string GroepId) => await lidService.GetLedenByGroepId(GroepId);

    public async Task<List<Tak>> GetAllTakken([Service] ILidService lidService) => await lidService.GetAllTakken();

    public async Task<List<Groep>> GetAllGroepen([Service] ILidService lidService) => await lidService.GetAllGroepen();

    public async Task<Tak> GetTak([Service] ILidService lidService, string TakId) => await lidService.GetTak(TakId);

    public async Task<Groep> GetGroep([Service] ILidService lidService, string GroepId) => await lidService.GetGroep(GroepId);

}