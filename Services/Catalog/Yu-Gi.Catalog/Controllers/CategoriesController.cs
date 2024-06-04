using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yu_Gi.Catalog.Dtos.CategoryDtos;
using Yu_Gi.Catalog.Services.CategoryServices;

namespace Exodia.Catalog.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CategoriesController : ControllerBase
{
	private readonly ICategoryService _categoryService;

	public CategoriesController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}
	[HttpGet]
	public async Task<IActionResult> GetAllCategory()
	{
		var values = await _categoryService.GetAllCategoriesAsync();
		return Ok(values);
	}
	[HttpGet]
	public async Task<IActionResult> GetCategoryById(string id)
	{
		var values = await _categoryService.GetByIdCategoryAsync(id);
		return Ok(values);
	}
	[HttpPost]
	public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
	{
		await _categoryService.CreateCategoryAsync(createCategoryDto);
		return Ok();
	}
	[HttpDelete]
	public async Task<IActionResult> DeleteCategory(string id)
	{
		await _categoryService.DeleteCategoryAsync(id);
		return Ok();
	}
	[HttpPut]
	public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
	{
		await _categoryService.UpdateCategoryAsync(updateCategoryDto);
		return Ok();
	}
}
