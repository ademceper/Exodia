using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yu_Gi.Catalog.Dtos.ProductImageDtos;
using Yu_Gi.Catalog.Services.ProductImageServices;

namespace Exodia.Catalog.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
	private readonly IProductImageService _ProductImageService;

	public ProductImagesController(IProductImageService ProductImageService)
	{
		_ProductImageService = ProductImageService;
	}
	[HttpGet]
	public async Task<IActionResult> GetAllProductImage()
	{
		var values = await _ProductImageService.GetAllProductImageAsync();
		return Ok(values);
	}
	[HttpGet]
	public async Task<IActionResult> GetProductImageById(string id)
	{
		var values = await _ProductImageService.GetByIdProductImageAsync(id);
		return Ok(values);
	}
	[HttpPost]
	public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
	{
		await _ProductImageService.CreateProductImageAsync(createProductImageDto);
		return Ok();
	}
	[HttpDelete]
	public async Task<IActionResult> DeleteProductImage(string id)
	{
		await _ProductImageService.DeleteProductImageAsync(id);
		return Ok();
	}
	[HttpPut]
	public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
	{
		await _ProductImageService.UpdateProductImageAsync(updateProductImageDto);
		return Ok();
	}
}
