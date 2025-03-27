using FoodShopBilling.Application.Interfaces.Services;

namespace FoodShopBilling.Api.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
