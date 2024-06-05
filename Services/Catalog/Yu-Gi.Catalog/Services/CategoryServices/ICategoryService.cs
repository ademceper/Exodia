using Yu_Gi.Catalog.Dtos.CategoryDtos;

namespace Yu_Gi.Catalog.Services.CategoryServices;

public interface ICategoryService
{
	Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
	Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
	Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
	Task DeleteCategoryAsync(string id);
	Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
}
