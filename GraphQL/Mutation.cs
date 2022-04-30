namespace Leden.API.GraphQL;

public class Mutation{
    public async Task<AddLidPayload> AddLid([Service] ILidService lidService, AddLidInput input){
        var newLid = new Lid(){
            Naam = input.Naam,
            Voornaam = input.Voornaam,
            Tak = input.Tak,
            Groep = input.Groep,
            Adres1 = input.Adres1,
            Adres2 = input.Adres2,
            Email = input.Email,
            Telefoon = input.Telefoon,
            Gsm = input.Gsm,
            Geboortedatum = input.Geboortedatum,
            Geslacht = input.Geslacht,
            Beperking = input.Beperking,
            VerminderdLidgeld = input.VerminderdLidgeld
        };
        var created = await lidService.AddLid(newLid);
        return new AddLidPayload(created);
    }

    public async Task<AddTakPayload> AddTak([Service] ILidService lidService, AddTakInput input)
    {
        var newTak = new Tak(){
            TakNaam = input.TakNaam
        };
        var created =  await lidService.AddTak(newTak);
        return new AddTakPayload(created);
    }

    public async Task<AddGroepPayload> AddGroep([Service] ILidService lidService, AddGroepInput input){
        var newGroep = new Groep(){
            GroepNaam = input.GroepNaam,
            Site = input.Site,
            Email = input.Email,
            Oprichtingsdatum = input.Oprichtingsdatum,
            Rekeningnummer = input.Rekeningnummer,
            Adres = input.Adres,
            Postcode = input.Postcode,
            Gemeente = input.Gemeente,
            Groepsleider1 = input.Groepsleider1,
            Groepsleider2 = input.Groepsleider2,
            Secretaris = input.Secretaris,
            Penningmeester = input.Penningmeester
        };
        var created = await lidService.AddGroep(newGroep);
        return new AddGroepPayload(created);
    }

    public async Task<UpdateLidPayload> UpdateLid([Service] ILidService lidService, UpdateLidInput input){
        var updatedLid = new Lid(){
            Naam = input.Naam,
            Voornaam = input.Voornaam,
            Tak = input.Tak,
            Groep = input.Groep,
            Adres1 = input.Adres1,
            Adres2 = input.Adres2,
            Email = input.Email,
            Telefoon = input.Telefoon,
            Gsm = input.Gsm,
            Geboortedatum = input.Geboortedatum,
            Geslacht = input.Geslacht,
            Beperking = input.Beperking,
            VerminderdLidgeld = input.VerminderdLidgeld
        };
        var updated = await lidService.UpdateLid(input.lidId, updatedLid);
        return new UpdateLidPayload(updated);
    }

    public async Task<UpdateTakPayload> UpdateTak([Service] ILidService lidService, UpdateTakInput input)
    {
        var updatedTak = new Tak(){
            TakNaam = input.TakNaam
        };
        var updated =  await lidService.UpdateTak(input.takId, updatedTak);
        return new UpdateTakPayload(updated);
    }

    public async Task<UpdateGroepPayload> UpdateGroep([Service] ILidService lidService, UpdateGroepInput input){
        var updatedGroep = new Groep(){
            GroepNaam = input.GroepNaam,
            Site = input.Site,
            Email = input.Email,
            Oprichtingsdatum = input.Oprichtingsdatum,
            Rekeningnummer = input.Rekeningnummer,
            Adres = input.Adres,
            Postcode = input.Postcode,
            Gemeente = input.Gemeente,
            Groepsleider1 = input.Groepsleider1,
            Groepsleider2 = input.Groepsleider2,
            Secretaris = input.Secretaris,
            Penningmeester = input.Penningmeester
        };
        var updated = await lidService.UpdateGroep(input.groepId, updatedGroep);
        return new UpdateGroepPayload(updated);
    }

    public async Task<DeleteLidPayload> DeleteLid([Service] ILidService lidService, DeleteLidInput input){
        await lidService.DeleteLid(input.lidId);
        return new DeleteLidPayload(input.lidId);
    }

    public async Task<DeleteTakPayload> DeleteTak([Service] ILidService lidService, DeleteTakInput input){
        await lidService.DeleteTak(input.takId);
        return new DeleteTakPayload(await lidService.GetTak(input.takId));
    }

    public async Task<DeleteGroepPayload> DeleteGroep([Service] ILidService lidService, DeleteGroepInput input){
        await lidService.DeleteGroep(input.groepId);
        return new DeleteGroepPayload(input.groepId);
    }
    
}