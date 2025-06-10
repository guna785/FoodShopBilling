using FoodShopBilling.Application.Interfaces.Services;

namespace FoodShopBilling.UI.Web.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
