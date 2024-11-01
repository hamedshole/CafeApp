using AutoMapper;
using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;

namespace CafeApp.Business.Helpers
{
    internal class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<TableEntity, TableDto>();
            CreateMap<CreateTableParameter, TableEntity>();
            CreateMap<UpdateTableParameter, TableEntity>();


        }
    }
}
