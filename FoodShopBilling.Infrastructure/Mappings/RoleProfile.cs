using AutoMapper;
using FoodShopBilling.Infrastructure.Models.Identity;
using FoodShopBilling.Application.Responses.Identity;

namespace FoodShopBilling.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            _ = CreateMap<RoleResponse, ApplicationRole>().ReverseMap();
        }
    }
}
