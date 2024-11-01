﻿using CafeApp.Business.Helpers.Dtos;
using Microsoft.AspNetCore.Components;

namespace CafeApp.Shared.Components.MenuComponents
{
    public partial class CategoryItem
    {
        [Parameter]
        public ProductCategoryModel Item { get; set; }
    }
}
