using FoodShopBilling.Utilities.Interfaces.Common;
namespace FoodShopBilling.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        int UserId { get; }
        string UserName { get; }
        string IpAddress { get; }
        bool IsAdmin { get; }
    }
}
