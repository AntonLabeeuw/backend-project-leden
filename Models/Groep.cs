namespace Leden.API.Models;

public class Groep {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? GroepId { get; set; }
    public string? GroepNaam { get; set; }
    public string? Site { get; set; }
    public string? Email { get; set; }
    public string? Oprichtingsdatum { get; set; }
    public string? Rekeningnummer { get; set; }
    public string? Adres { get; set; }
    public string? Postcode { get; set; }
    public string? Gemeente { get; set; }
    public string? Groepsleider1 { get; set; }
    public string? Groepsleider2 { get; set; }
    public string? Secretaris { get; set; }
    public string? Penningmeester { get; set; }
}