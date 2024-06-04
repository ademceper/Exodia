using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Yu_Gi.Catalog.Entities;

public class Product
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string? Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string? CategoryId { get; set; }
    [BsonIgnore]
    public Category? Category { get; set; }

}
