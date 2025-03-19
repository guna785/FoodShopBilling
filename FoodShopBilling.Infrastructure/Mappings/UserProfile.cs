using AutoMapper;
using FoodShopBilling.Infrastructure.Models.Identity;
using FoodShopBilling.Utilities.Responses.Identity;

namespace FoodShopBilling.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            _ = CreateMap<UserResponse, ApplicationUser>().ReverseMap();
        }
    }
}
