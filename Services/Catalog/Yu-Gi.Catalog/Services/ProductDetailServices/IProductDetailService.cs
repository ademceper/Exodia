using Yu_Gi.Catalog.Dtos.ProductDetailDtos;

namespace Yu_Gi.Catalog.Services.ProductDetailServices;

public interface IProductDetailService
{
	Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
	Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
	Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
	Task DeleteProductDetailAsync(string id);
	Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
}
