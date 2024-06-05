using AutoMapper;
using MongoDB.Driver;
using Yu_Gi.Catalog.Dtos.ProductImageDtos;
using Yu_Gi.Catalog.Entities;
using Yu_Gi.Catalog.Services.ProductImageServices;
using Yu_Gi.Catalog.Settings;

namespace Yu_Gi.Catalog.Services.ProductImageDetailServices;

public class ProductImageService : IProductImageService
{
	private readonly IMapper _mapper;
	private readonly IMongoCollection<ProductImage> _productImageCollection;
	public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
	{
		var client = new MongoClient(_databaseSettings.ConnectionString);
		var database = client.GetDatabase(_databaseSettings.DatabaseName);
		_productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
		_mapper = mapper;
	}

	public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
	{
		var values = _mapper.Map<ProductImage>(createProductImageDto);
		await _productImageCollection.InsertOneAsync(values);
	}

	public async Task DeleteProductImageAsync(string id)
	{
		await _productImageCollection.DeleteOneAsync(x => x.Id == id);
	}

	public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
	{
		var values = await _productImageCollection.Find(x => true).ToListAsync();
		return _mapper.Map<List<ResultProductImageDto>>(values);
	}

	public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
	{
		var values = await _productImageCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
		return _mapper.Map<GetByIdProductImageDto>(values);
	}

	public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
	{
		var values = _mapper.Map<ProductImage>(updateProductImageDto);
		await _productImageCollection.FindOneAndReplaceAsync(x => x.Id == updateProductImageDto.Id, values);
	}
}
