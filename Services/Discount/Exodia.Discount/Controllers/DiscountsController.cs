using Exodia.Discount.Dtos;
using Exodia.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exodia.Discount.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class DiscountsController : ControllerBase
{
	private readonly IDiscountService _discountService;

	public DiscountsController(IDiscountService discountService)
	{
		_discountService = discountService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllCoupons()
	{
		var values = await _discountService.GetAllCouponAsync();
		return Ok(values);
	}

	[HttpGet]
	public async Task<IActionResult> GetCouponById(int id)
	{
		var values = await _discountService.GetByIdCouponAsync(id);
		return Ok(values);
	}

	[HttpPost]
	public async Task<IActionResult> CreateCoupon(CreateCouponDto createCoupondto)
	{
		await _discountService.CreateCouponAsync(createCoupondto);
		return Ok();
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteCoupon(int id)
	{
		await _discountService.DeleteCouponAsync(id);
		return Ok();
	}

	[HttpPut]
	public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
	{
		await _discountService.UpdateCouponAsync(updateCouponDto);
		return Ok();
	}
}
