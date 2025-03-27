using AutoMapper;
using FoodShopBilling.Application.Features.Products.Commands.AddEdit;
using FoodShopBilling.Application.Features.SalesDetails.Commands.AddEdit;
using FoodShopBilling.Domain.Entities;
using FoodShopBilling.Utilities.Responses.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            _ = CreateMap<ProductResponse, Products>().ReverseMap();
            _ = CreateMap<AddEditProductCommand, Products>().ReverseMap();

        }
    }
}
