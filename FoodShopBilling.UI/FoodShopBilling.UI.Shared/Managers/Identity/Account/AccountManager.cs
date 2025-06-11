
using Microsoft.Extensions.Configuration;
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.UI.Shared.Endpoints;
using FoodShopBilling.UI.Shared.Extensions;
using FoodShopBilling.Utilities.Requests.Identity;
using System.Net.Http.Json;

namespace FoodShopBilling.UI.Shared.Managers.Identity.Account
{
    public class AccountManager : IAccountManager
    {
        private readonly HttpClient _httpClient;

        public AccountManager(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(configuration["BaseAddress"]!);
            }
        }

        public async Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string Id)
        {
            var response = await _httpClient.PostAsJsonAsync(AccountEndpoints.ChangePassword(Id), model);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult();
            }
            return await Result.FailAsync("Nework Error");
        }

        public async Task<IResult> UpdateProfileAsync(UpdateProfileRequest model)
        {
            var response = await _httpClient.PostAsJsonAsync(AccountEndpoints.UpdateProfile, model);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult();
            }
            return await Result.FailAsync("Nework Error");
        }

        public async Task<IResult<string>> GetProfilePictureAsync(string userId)
        {
            var response = await _httpClient.GetAsync(AccountEndpoints.GetProfilePicture(userId));
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId)
        {
            var response = await _httpClient.PostAsJsonAsync(AccountEndpoints.UpdateProfilePicture(userId), request);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult> UpdatePasswordAsync(UpdatePasswordRequest model, string Id)
        {
            var response = await _httpClient.PostAsJsonAsync(AccountEndpoints.UpdatePassword(Id), model);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }
    }
}