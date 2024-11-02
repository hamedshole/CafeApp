using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TableEntity, TableDto>();
            CreateMap<CreateTableParameter, TableEntity>();
            CreateMap<UpdateTableParameter, TableEntity>();
            CreateMap<UnitEntity, UnitDto>()
                .ForMember(x => x.Parent, opt => opt.MapFrom(x => x.Parent!.Title));
            CreateMap<UnitEntity, UnitDetailModel>();
            CreateMap<CreateUnitParameter, UnitEntity>();
            CreateMap<UpdateUnitParameter, UnitEntity>();
            CreateMap<MaterialEntity, MaterialDto>()
                .ForMember(x => x.Unit, opt => opt.MapFrom(x => x.Unit!.Title));
            CreateMap<MaterialEntity, MaterialDetailModel>();
            CreateMap<CreateMaterialParameter, MaterialEntity>();
            CreateMap<UpdateMaterialParameter, MaterialEntity>();
            CreateMap<AdditiveEntity, AdditiveDto>()
                .ForMember(x => x.Material, opt => opt.MapFrom(x => x.Material!.Title));
            CreateMap<CreateAdditiveParameter, AdditiveEntity>();
            CreateMap<UpdateAdditiveParameter, AdditiveEntity>();
            CreateMap<AdditiveEntity, AdditiveDetailModel>();
            CreateMap<ProductAdditiveEntity, AdditiveSelectModel>()
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Additive!.Title))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Additive!.Id));
            CreateMap<ProductCategoryEntity, ProductCategoryDto>();
            CreateMap<CreateProductCategoryParameter, ProductCategoryEntity>();
            CreateMap<UpdateProductCategoryParameter, ProductCategoryEntity>();
            CreateMap<ProductEntity, ProductDto>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category!.Title));
            CreateMap<CreateProductParameter, ProductEntity>()
                .ForMember(x => x.Additives, opt => opt.Ignore())
                .ForMember(x => x.Materials, opt => opt.Ignore());
            CreateMap<UpdateProductParameter, ProductEntity>()
                .ForMember(x => x.Additives, opt => opt.Ignore())
                .ForMember(x => x.Materials, opt => opt.Ignore());
            CreateMap<ProductMaterialEntity, ProductMaterialModel>();
            CreateMap<ProductMaterialEntity, MaterialSelectModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.MaterialId))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Material!.Title))
                .ForMember(x => x.Unit, opt => opt.MapFrom(x => x.Material!.Unit!.Title)); CreateMap<ProductAdditiveEntity, ProductAdditiveModel>();
            CreateMap<ProductEntity, ProductDetailModel>();
            CreateMap<ProductPriceLogEntity, PriceLogDto>()
                .ForMember(x => x.Start, opt => opt.MapFrom(x => x.StartTime))
                .ForMember(x => x.End, opt => opt.MapFrom(x => x.EndTime));
            CreateMap<AdditivePriceLogEntity, PriceLogDto>()
                .ForMember(x => x.Start, opt => opt.MapFrom(x => x.StartTime))
                .ForMember(x => x.End, opt => opt.MapFrom(x => x.EndTime));
            CreateMap<MaterialPriceLogEntity, MaterialPriceLogModel>()

                .ForMember(x => x.Start, opt => opt.MapFrom(x => x.StartTime))
                .ForMember(x => x.End, opt => opt.MapFrom(x => x.EndTime));

            CreateMap<ProductCategoryEntity, MenuCategoryModel>();
            CreateMap<ProductEntity, MenuProductModel>();
            CreateMap<ProductAdditiveEntity, MenuAdditiveDto>()
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Additive!.Title))
                .ForMember(x => x.Amount, opt => opt.MapFrom(x => x.Additive!.Amount.ToString()));

            CreateMap<InventoryEntity, InventoryDto>();
            CreateMap<CreateInventoryParameter, InventoryEntity>();
            CreateMap<UpdateInventoryParameter, InventoryEntity>();


        }
    }
}
