using Exodia.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Exodia.Discount.Context;

public class AppDbContext : DbContext
{
	private readonly IConfiguration _configuration;
	private readonly string _connectionString;

	public AppDbContext(IConfiguration configuration)
	{
		_configuration = configuration;
		_connectionString = _configuration.GetConnectionString("DefaultConnection");
	}
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
	}
    public DbSet<Coupon> Coupons { get; set; }

	public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
