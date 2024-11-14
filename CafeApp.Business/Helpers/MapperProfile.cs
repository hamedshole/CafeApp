using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Common;
using CafeApp.Domain.Entities;
using System.Globalization;

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


            CreateMap<UserEntity, UserDto>()
                .ForMember(x => x.GenderStr, opt => opt.MapFrom(x => GetGender(x.Gender)))
                .ForMember(x => x.Gender, opt => opt.MapFrom(x => (byte)x.Gender))
                .ForMember(x => x.BirthdayStr, opt => opt.MapFrom(x => x.Birthday!.Value.ToString("yyyy/MM/dd", new CultureInfo("fa-ir"))));

            CreateMap<CreateUserParameter, UserEntity>()
                .ForMember(x => x.Gender, opt => opt.MapFrom(x => (Gender)x.Gender));
            CreateMap<UpdateUserParameter, UserEntity>()
              .ForMember(x => x.Gender, opt => opt.MapFrom(x => (Gender)x.Gender));

            CreateMap<CustomerEntity, CustomerDto>()
                .ForMember(x => x.Gender, opt => opt.MapFrom(x => (byte)x.Gender))
                .ForMember(x => x.GenderStr, opt => opt.MapFrom(x => GetGender(x.Gender)))
                .ForMember(x => x.BirthdayStr, opt => opt.MapFrom(x => x.Birthday!.Value.ToString("yyyy/MM/dd", new CultureInfo("fa-ir"))));
            CreateMap<UpdateCustomerParameter, CustomerEntity>()
                .ForMember(x => x.Gender, opt => opt.MapFrom(x => (byte)x.Gender))
                .ForMember(x => x.Gender, opt => opt.MapFrom(x => (Gender)x.Gender));
            CreateMap<CreateCustomerParameter, CustomerEntity>()
                .ForMember(x => x.Gender, opt => opt.MapFrom(x => (Gender)x.Gender));

            CreateMap<OrderEntity, OrderDto>()
                .ForMember(x => x.Customer, opt => opt.MapFrom(x => x.Customer!.FullName))
                .ForMember(x=>x.Date,opt=>opt.MapFrom(x=>x.Time.ToString("yyyy/MM/dd",new CultureInfo("fa-ir"))))
                .ForMember(x=>x.Time,opt=>opt.MapFrom(x=>x.Time.ToString("HH:mm:ss")));
            CreateMap<ProductCategoryEntity, DashboardCategoryModel>()
                .ForMember(x=>x.Items,opt=>opt.MapFrom(x=>x.Products));
            CreateMap<ProductEntity,DashboardProductModel>();
        }
        public static string GetGender(Gender gender)
        {
            string res = string.Empty;

            return gender switch
            {
                Gender.Male => "مذکر",
                Gender.Female => "مونث",
                _ => string.Empty,
            };
        }
    }
}
