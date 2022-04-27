namespace Leden.API.Models;

public class Tak {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? TakId { get; set; }
    public string? TakNaam { get; set; }
}