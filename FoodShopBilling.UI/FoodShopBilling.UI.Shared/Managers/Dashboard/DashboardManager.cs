
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.UI.Shared.Extensions;
using FoodShopBilling.UI.Shared.Endpoints;
using FoodShopBilling.Utilities.Responses.Features;

namespace FoodShopBilling.UI.Shared.Managers.Dashboard
{
    public class DashboardManager : IDashboardManager
    {
        private readonly HttpClient _httpClient;

        public DashboardManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IResult<string>> GetDataAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(DashboardEndpoints.GetData);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }
    }
}
