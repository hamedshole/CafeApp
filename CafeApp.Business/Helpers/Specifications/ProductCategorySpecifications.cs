﻿using CafeApp.Business.Helpers.Dtos;
using CafeApp.Domain.Entities;
using System.Linq.Expressions;

namespace CafeApp.Business.Helpers.Specifications
{
    public class ProductCategorySpecifications:BaseSpecification<ProductCategoryEntity>
    {
        public static ProductCategorySpecifications FromParameter(ListProductCategoryParameter parameter)
        {
            ProductCategorySpecifications productCategorySpecifications = new ProductCategorySpecifications();
            productCategorySpecifications.AddFilters(parameter);
            return productCategorySpecifications;
        }

        public static ProductCategorySpecifications Get(GetCategoryParameter parameter)
        {
            ProductCategorySpecifications specs = new ProductCategorySpecifications();
            specs.SetFilterCondition(x=>x.Id == parameter.Id);
            return specs;
        }

        public ProductCategorySpecifications AddFilters(ListProductCategoryParameter parameter)
        {
            if(!string.IsNullOrEmpty(parameter.Title))
                SetFilterCondition(x=>x.Title.Contains(parameter.Title));
          
            if(parameter.IsActive is bool ia )
                SetFilterCondition(x=>x.IsActive==ia);
            return this;
        }
        public ProductCategorySpecifications AddFilter(Expression<Func<ProductCategoryEntity,bool>> expression)
        {
            SetFilterCondition(expression);
            return this;
        }
        public ProductCategorySpecifications IncludeProduct()
        {
            AddInclude("Products.Additives.Additive");
            return this;
        }
    }
}
