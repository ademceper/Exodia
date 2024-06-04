﻿using AutoMapper;
using MongoDB.Driver;
using Yu_Gi.Catalog.Dtos.ProductDtos;
using Yu_Gi.Catalog.Entities;
using Yu_Gi.Catalog.Settings;

namespace Yu_Gi.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
	private readonly IMapper _mapper;
	private readonly IMongoCollection<Product> _productCollection;
	public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
	{
		var client = new MongoClient(_databaseSettings.ConnectionString);
		var database = client.GetDatabase(_databaseSettings.DatabaseName);
		_productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
		_mapper = mapper;
	}

	public async Task CreateProductAsync(CreateProductDto createProductDto)
	{
		var values = _mapper.Map<Product>(createProductDto);
		await _productCollection.InsertOneAsync(values);
	}

	public async Task DeleteProductAsync(string id)
	{
		await _productCollection.DeleteOneAsync(x => x.Id == id);
	}

	public async Task<List<ResultProductDto>> GetAllProductsAsync()
	{
		var values = await _productCollection.Find(x=>true).ToListAsync();
		return _mapper.Map<List<ResultProductDto>>(values);
	}

	public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
	{
		var values = await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
		return _mapper.Map<GetByIdProductDto>(values);
	}

	public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
	{
		var values = _mapper.Map<Product>(updateProductDto);
		await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id, values);
	}
}
