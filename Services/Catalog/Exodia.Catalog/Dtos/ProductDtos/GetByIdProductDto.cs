namespace Yu_Gi.Catalog.Dtos.ProductDtos;

public class GetByIdProductDto
{
	public string? Id { get; set; }
	public string? Name { get; set; }
	public decimal Price { get; set; }
	public string? ImageUrl { get; set; }
	public string? Description { get; set; }
	public string? CategoryId { get; set; }
}
