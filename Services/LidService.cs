namespace Leden.API.Services;

public interface ILidService
{
    Task<Groep> AddGroep(Groep newGroep);
    Task<Lid> AddLid(Lid newLid);
    Task<Tak> AddTak(Tak newTak);
    Task<List<Groep>> GetAllGroepen();
    Task<List<Lid>> GetAllLeden();
    Task<List<Tak>> GetAllTakken();
    Task<Groep> GetGroep(string id);
    Task<List<Lid>> GetLedenByGroepId(string GroepId);
    Task<List<Lid>> GetLedenByTakId(string TakId);
    Task<Lid> GetLid(string id);
    Task<Tak> GetTak(string id);
    Task<Tak> UpdateTak(Tak tak);
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

    public async Task<Tak> UpdateTak(Tak tak) => await _takRepository.UpdateTak(tak);

    public async Task<List<Groep>> GetAllGroepen() => await _groepRepository.GetAllGroepen();

    public async Task<Groep> GetGroep(string id) => await _groepRepository.GetGroep(id);

    public async Task<Groep> AddGroep(Groep newGroep) => await _groepRepository.AddGroep(newGroep);
    /*
        public async Task SetUpDummyData()
        {
            if (!(await _takRepository.GetAllTakken()).Any())
            {
                var takken = new List<Tak>()
                {
                    // new Tak(){
                    //     TakId = Guid.NewGuid().ToString(), TakNaam = "Kapoenen"
                    // },
                    // new Tak(){
                    //     TakId = Guid.NewGuid().ToString(), TakNaam = "Welpen"
                    // },
                    // new Tak(){
                    //     TakId = Guid.NewGuid().ToString(), TakNaam = "Jongverkenners"
                    // },
                    // new Tak(){
                    //     TakId = Guid.NewGuid().ToString(), TakNaam = "Verkenners"
                    // },
                    // new Tak(){
                    //     TakId = Guid.NewGuid().ToString(), TakNaam = "JIN's"
                    // },
                };

                foreach (var tak in takken)
                {
                    await _takRepository.AddTak(tak);
                }
            }

            if (!(await _groepRepository.GetAllGroepen()).Any())
            {
                var groepen = new List<Groep>()
                {
                    // new Groep(){
                    //     GroepId = string.NewGuid(), GroepNaam = "Karel Van De Poele", Site = "https://scoutslichtervelde.be", Email = "groepsleiding@scoutslichtervelde.be", Oprichtingsdatum = "01/09/1960", Rekeningnummer = "BE12 3456 7891 0111", Adres = "Oude Bruggeweg 16", Postcode = "8810", Gemeente = "Lichtervelde", Groepsleider1 = "Robbe Desmet", Groepsleider2 = "Sybe Raedt", Secretaris = "Anton Labeeuw", Penningmeester = "Siemen Delbecque"
                    // },
                    // new Groep(){
                    //     GroepId = Guid.NewGuid(), GroepNaam = "Karel Van De Poele 2", Site = "https://scoutslichtervelde2.be", Email = "groepsleiding@scoutslichtervelde2.be", Oprichtingsdatum = "01/09/1962", Rekeningnummer = "BE98 7654 3210 0123", Adres = "Oude Bruggeweg 12", Postcode = "8820", Gemeente = "Torhout", Groepsleider1 = "Robbe", Groepsleider2 = "Sybe", Secretaris = "Anton", Penningmeester = "Siemen"
                    // },
                };

                foreach (var groep in groepen)
                {
                    await _groepRepository.AddGroep(groep);
                }
            }

            if (!(await _lidRepository.GetAllLeden()).Any())
            {
                var takken = await _takRepository.GetAllTakken();
                var groepen = await _groepRepository.GetAllGroepen();
                var leden = new List<Lid>(){
                    // new Lid(){
                    //     LidId = Guid.NewGuid(), Naam = "Labeeuw", Voornaam = "Anton", Tak = takken[3], Groep = groepen[1], Adres1 = "straat nummer", Email = "anton.labeeuw@student.howest.be", Telefoon = "012345678", Gsm = "0123456789", Geboortedatum = "28/10/1999", Geslacht = "man", Beperking = 0, VerminderdLidgeld = 0
                    // }
                };
            }
        }
        */
}