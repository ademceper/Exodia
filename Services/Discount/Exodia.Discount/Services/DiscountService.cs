using Dapper;
using Exodia.Discount.Context;
using Exodia.Discount.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Exodia.Discount.Services;

public class DiscountService : IDiscountService
{
	private readonly AppDbContext _context;
    public DiscountService(AppDbContext context)
    {
        _context = context;
    }
    public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
	{
		string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
		var parameters = new DynamicParameters();
		parameters.Add("@code", createCouponDto.Code);
		parameters.Add("@rate", createCouponDto.Rate);
		parameters.Add("@isActive", createCouponDto.IsActive);
		parameters.Add("@validDate", createCouponDto.ValidDate);

		using(var connection = _context.CreateConnection())
		{
			await connection.ExecuteAsync(query, parameters);
		}

	}

	public async Task DeleteCouponAsync(int couponId)
	{
		string query = "delete from Coupons where Id=@Id";
		var parameters = new DynamicParameters();
		parameters.Add("@Id", couponId);

		using( var connection = _context.CreateConnection())
		{
			await connection.ExecuteAsync(query, parameters);
		}
	}

	public async Task<List<ResultCouponDto>> GetAllCouponAsync()
	{
		string query = "select * from Coupons";
		using(var connection = _context.CreateConnection())
		{
			var values = await connection.QueryAsync<ResultCouponDto>(query);
			return values.ToList();
		}
	}

	public async Task<GetByIdCouponDto> GetByIdCouponAsync(int couponId)
	{
		string query = "select * from Coupons where Id=@Id";
		var parameters = new DynamicParameters();
		parameters.Add("@Id", couponId);
		using(var connection = _context.CreateConnection())
		{
			var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query,parameters);
			return values;
		}
	}

	public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
	{
		string query = "update Coupons set Code=@Code,Rate=@Rate,IsActive=@IsActive,ValidDate=@ValidDate where Id=@Id";
		var parameters = new DynamicParameters();
		parameters.Add("@Code", updateCouponDto.Code);
		parameters.Add("@Rate", updateCouponDto.Rate);
		parameters.Add("@IsActive", updateCouponDto.IsActive);
		parameters.Add("@ValidDate", updateCouponDto.ValidDate);
		parameters.Add("@Id", updateCouponDto.Id);

		using (var connection = _context.CreateConnection())
		{
			await connection.ExecuteAsync(query,parameters);
		}
	}
}
