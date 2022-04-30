namespace Leden.API.GraphQL.Leden;

public record UpdateGroepInput(string groepId, string GroepNaam, string Site, string Email, string Oprichtingsdatum, string Rekeningnummer, string Adres, string Postcode, string Gemeente, string Groepsleider1, string Groepsleider2, string Secretaris, string Penningmeester);