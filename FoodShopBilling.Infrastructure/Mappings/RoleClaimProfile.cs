using AutoMapper;
using FoodShopBilling.Infrastructure.Models.Identity;
using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Utilities.Responses.Identity;

namespace FoodShopBilling.Infrastructure.Mappings
{
    public class RoleClaimProfile : Profile
    {
        public RoleClaimProfile()
        {
            _ = CreateMap<RoleClaimResponse, ApplicationRoleClaim>()
                .ForMember(nameof(ApplicationRoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(ApplicationRoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();

            _ = CreateMap<RoleClaimRequest, ApplicationRoleClaim>()
                .ForMember(nameof(ApplicationRoleClaim.ClaimType), opt => opt.MapFrom(c => c.Type))
                .ForMember(nameof(ApplicationRoleClaim.ClaimValue), opt => opt.MapFrom(c => c.Value))
                .ReverseMap();
        }
    }
}
