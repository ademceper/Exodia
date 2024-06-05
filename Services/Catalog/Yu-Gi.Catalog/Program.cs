
using Microsoft.Extensions.Options;
using System.Reflection;
using Yu_Gi.Catalog.Services.CategoryServices;
using Yu_Gi.Catalog.Services.ProductDetailDetailServices;
using Yu_Gi.Catalog.Services.ProductDetailServices;
using Yu_Gi.Catalog.Services.ProductImageDetailServices;
using Yu_Gi.Catalog.Services.ProductImageServices;
using Yu_Gi.Catalog.Services.ProductServices;
using Yu_Gi.Catalog.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
	return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
