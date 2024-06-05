using AutoMapper;
using MongoDB.Driver;
using Yu_Gi.Catalog.Dtos.CategoryDtos;
using Yu_Gi.Catalog.Entities;
using Yu_Gi.Catalog.Settings;
using static MongoDB.Driver.WriteConcern;

namespace Yu_Gi.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
	private readonly IMongoCollection<Category> _categoryCollection;
	private readonly IMapper _mapper;
	public CategoryService( IMapper mapper, IDatabaseSettings _databaseSettings)
	{
		var client = new MongoClient(_databaseSettings.ConnectionString);
		var database = client.GetDatabase(_databaseSettings.DatabaseName);
		_categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
		_mapper = mapper;
	}

	public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
	{
		var value = _mapper.Map<Category>(createCategoryDto);
		await _categoryCollection.InsertOneAsync(value);
	}

	public async Task DeleteCategoryAsync(string id)
	{
		await _categoryCollection.DeleteOneAsync(x => x.Id == id);
	}

	public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
	{
		var values = await _categoryCollection.Find(x => true).ToListAsync();
		return _mapper.Map<List<ResultCategoryDto>>(values);
	}

	public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
	{
		var value = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
		return _mapper.Map<GetByIdCategoryDto>(value);

	}

	public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
	{
		var value = _mapper.Map<Category>(updateCategoryDto);
		await _categoryCollection.FindOneAndReplaceAsync(x=>x.Id == updateCategoryDto.Id, value);
	}
}
