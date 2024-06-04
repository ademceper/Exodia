﻿using AutoMapper;
using MongoDB.Driver;
using Yu_Gi.Catalog.Dtos.ProductDetailDtos;
using Yu_Gi.Catalog.Entities;
using Yu_Gi.Catalog.Services.ProductDetailServices;
using Yu_Gi.Catalog.Settings;

namespace Yu_Gi.Catalog.Services.ProductDetailDetailServices;

public class ProductDetailService : IProductDetailService
{
	private readonly IMapper _mapper;
	private readonly IMongoCollection<ProductDetail> _productDetailCollection;
	public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
	{
		var client = new MongoClient(_databaseSettings.ConnectionString);
		var database = client.GetDatabase(_databaseSettings.DatabaseName);
		_productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
		_mapper = mapper;
	}

	public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
	{
		var values = _mapper.Map<ProductDetail>(createProductDetailDto);
		await _productDetailCollection.InsertOneAsync(values);
	}

	public async Task DeleteProductDetailAsync(string id)
	{
		await _productDetailCollection.DeleteOneAsync(x => x.Id == id);
	}

	public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
	{
		var values = await _productDetailCollection.Find(x => true).ToListAsync();
		return _mapper.Map<List<ResultProductDetailDto>>(values);
	}

	public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
	{
		var values = await _productDetailCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
		return _mapper.Map<GetByIdProductDetailDto>(values);
	}

	public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
	{
		var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
		await _productDetailCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDetailDto.Id, values);
	}
}
