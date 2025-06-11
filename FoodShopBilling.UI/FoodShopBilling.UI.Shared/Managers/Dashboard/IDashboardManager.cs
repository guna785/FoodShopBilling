//using RotaryHospital.Application.Features.Dashboards.Queries.GetData;

using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Responses.Features;

namespace FoodShopBilling.UI.Shared.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<string>> GetDataAsync();
    }
}