using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DaneelBot.Database.Dto;

public abstract class DtoModel {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}