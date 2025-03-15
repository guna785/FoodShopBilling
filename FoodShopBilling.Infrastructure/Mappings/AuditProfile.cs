using AutoMapper;
using FoodShopBilling.Infrastructure.Models.Audit;
using FoodShopBilling.Application.Responses.Audit;

namespace FoodShopBilling.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            _ = CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}
