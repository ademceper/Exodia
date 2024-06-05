using Yu_Gi.Catalog.Dtos.ProductImageDtos;

namespace Yu_Gi.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
	Task<List<ResultProductImageDto>> GetAllProductImageAsync();
	Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
	Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
	Task DeleteProductImageAsync(string id);
	Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
}
