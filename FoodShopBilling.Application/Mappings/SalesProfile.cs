using AutoMapper;
using FoodShopBilling.Application.Features.SalesDetails.Commands.AddEdit;
using FoodShopBilling.Domain.Entities;
using FoodShopBilling.Utilities.Responses.Features;
using FoodShopBilling.Utilities.Responses.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Application.Mappings
{
    public class SalesProfile : Profile
    {
        public SalesProfile()
        {
            _ = CreateMap<SalesResponse, Sales>().ReverseMap();
            _ = CreateMap<AddEditSalesCommand, Sales>().ReverseMap();
        }
    }
}
