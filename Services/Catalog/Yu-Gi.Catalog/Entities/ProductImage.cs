using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Yu_Gi.Catalog.Entities;

public class ProductImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Image1 { get; set; }
    public string? Image2 { get; set; }
    public string? Image3 { get; set; }
    public string? ProductId { get; set; }
    [BsonIgnore]
    public Product? Product { get; set; }
}

