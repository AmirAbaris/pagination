namespace api.Models;

public record Passenger(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
    string Name,
    string IdNumber
);