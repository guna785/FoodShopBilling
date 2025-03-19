using AutoMapper;
using FoodShopBilling.Infrastructure.Models.Audit;
using FoodShopBilling.Utilities.Responses.Audit;

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
