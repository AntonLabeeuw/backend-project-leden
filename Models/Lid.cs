namespace Leden.API.Models;

public class Lid {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid LidId { get; set; }
    public string? Naam { get; set; }
    public string? Voornaam { get; set; }
    public Tak? Tak { get; set; }
    public Groep? Groep { get; set; }
    public string? Adres1 { get; set; }
    public string? Adres2 { get; set; }
    public string? Email { get; set; }
    public string? Telefoon { get; set; }
    public string? Gsm { get; set; }
    public string? Geboortedatum { get; set; }
    public string? Geslacht { get; set; }
    public int Beperking { get; set; }
    public int VerminderdLidgeld { get; set; }

}