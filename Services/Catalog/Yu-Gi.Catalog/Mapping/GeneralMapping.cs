using AutoMapper;
using Yu_Gi.Catalog.Dtos.CategoryDtos;
using Yu_Gi.Catalog.Dtos.ProductDetailDtos;
using Yu_Gi.Catalog.Dtos.ProductDtos;
using Yu_Gi.Catalog.Dtos.ProductImageDtos;
using Yu_Gi.Catalog.Entities;

namespace Yu_Gi.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
		CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

        CreateMap<Product, ResultProductDto>().ReverseMap();
		CreateMap<Product, CreateProductDto>().ReverseMap();
		CreateMap<Product, UpdateProductDto>().ReverseMap();
		CreateMap<Product, GetByIdProductDto>().ReverseMap();

		CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
		CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
		CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

		CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
		CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
		CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

	}
}
