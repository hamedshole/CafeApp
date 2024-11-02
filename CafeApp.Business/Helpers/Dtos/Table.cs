﻿using CafeApp.Business.Helpers.Common;
using CafeApp.Business.Helpers.Specifications;
using CafeApp.Domain.Entities;
using CafeApp.Domain.Interfaces;

namespace CafeApp.Business.Helpers.Dtos
{
    public class TableDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }

    public class ListTableParameter : PagingParameter,IGetParameter<TableEntity>
    {
        public string? Title { get; set; }
        public bool? IsActive { get; set; }
        public ISpecifications<TableEntity> GetSpecifications()
        {
            return TableSpecification.FromParameter(this);
        }
    }

    public class CreateTableParameter
    {
        public string Title { get; set; }
        public int Number { get; set; }

        public bool IsActive { get; set; }
    }
    public class UpdateTableParameter : CreateTableParameter
    {
        public Guid Id { get; set; }
    }
}
