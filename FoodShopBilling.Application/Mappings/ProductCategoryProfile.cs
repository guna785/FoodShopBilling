using AutoMapper;
using FoodShopBilling.Application.Features.ProductCategories.Commands.AddEdit;
using FoodShopBilling.Domain.Entities;
using FoodShopBilling.Utilities.Responses.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Mappings
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            _ = CreateMap<ProductCategoryResponse, ProductCategory>().ReverseMap();
            _ = CreateMap<AddEditProductCategoryCommand, ProductCategory>().ReverseMap();
        }
    }
}
