using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yu_Gi.Catalog.Dtos.ProductDetailDtos;
using Yu_Gi.Catalog.Dtos.ProductDtos;
using Yu_Gi.Catalog.Services.ProductDetailServices;
using Yu_Gi.Catalog.Services.ProductServices;

namespace Exodia.Catalog.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ProductDetailsController : ControllerBase
{
	private readonly IProductDetailService _ProductDetailService;

	public ProductDetailsController(IProductDetailService ProductDetailService)
	{
		_ProductDetailService = ProductDetailService;
	}
	[HttpGet]
	public async Task<IActionResult> GetAllProductDetail()
	{
		var values = await _ProductDetailService.GetAllProductDetailAsync();
		return Ok(values);
	}
	[HttpGet]
	public async Task<IActionResult> GetProductDetailById(string id)
	{
		var values = await _ProductDetailService.GetByIdProductDetailAsync(id);
		return Ok(values);
	}
	[HttpPost]
	public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
	{
		await _ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
		return Ok();
	}
	[HttpDelete]
	public async Task<IActionResult> DeleteProductDetail(string id)
	{
		await _ProductDetailService.DeleteProductDetailAsync(id);
		return Ok();
	}
	[HttpPut]
	public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
	{
		await _ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
		return Ok();
	}
}
