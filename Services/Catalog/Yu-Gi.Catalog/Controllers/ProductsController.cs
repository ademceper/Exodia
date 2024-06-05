using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yu_Gi.Catalog.Dtos.ProductDtos;
using Yu_Gi.Catalog.Services.ProductServices;

namespace Exodia.Catalog.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductsController(IProductService ProductService)
	{
		_productService = ProductService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllProducts()
	{
		var values = await _productService.GetAllProductsAsync();
		return Ok(values);
	}

	[HttpGet]
	public async Task<IActionResult> GetProductById(string id)
	{
		var values = await _productService.GetByIdProductAsync(id);
		return Ok(values);
	}

	[HttpPost]
	public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
	{
		await _productService.CreateProductAsync(createProductDto);
		return Ok();
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteProduct(string id)
	{
		await _productService.DeleteProductAsync(id);
		return Ok();
	}

	[HttpPut]
	public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
	{
		await _productService.UpdateProductAsync(updateProductDto);
		return Ok();
	}
}
