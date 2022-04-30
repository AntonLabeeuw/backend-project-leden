namespace Leden.API.GraphQL.Groepen;

public record AddGroepInput(string GroepNaam, string Site, string Email, string Oprichtingsdatum, string Rekeningnummer, string Adres, string Postcode, string Gemeente, string Groepsleider1, string Groepsleider2, string Secretaris, string Penningmeester);