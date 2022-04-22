namespace Leden.API.Models;

public class Tak {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid TakId { get; set; }
    public string? TakNaam { get; set; }
}