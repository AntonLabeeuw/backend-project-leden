namespace Leden.API.GraphQL.Leden;

public record AddLidInput(string Naam, string Voornaam, Tak Tak, Groep Groep, string Adres1, string Adres2, string Email, string Telefoon, string Gsm, string Geboortedatum, string Geslacht, int Beperking, int VerminderdLidgeld);