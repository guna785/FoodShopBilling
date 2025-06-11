using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Utilities.Responses.Identity;
using FoodShopBilling.UI.Shared.Extensions;
using System.Net.Http.Json;
using FoodShopBilling.UI.Shared.Endpoints;
using Microsoft.Extensions.Configuration;
using FoodShopBilling.UI.Shared.Storage;

namespace FoodShopBilling.UI.Shared.Managers.Identity.Users
{
    public class UserManager : IUserManager
    {
        private readonly HttpClient _httpClient;

        public UserManager(HttpClient httpClient,IConfiguration configuration,IClientSessionSecureStorage storage)
        {
            _httpClient = httpClient;
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(configuration["BaseAddress"]!);
            }
            
        }

        public async Task<IResult<List<UserResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(UserEndpoints.GetAll);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<List<UserResponse>>();
            }
            return await Result<List<UserResponse>>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<UserResponse>> GetAsync(string userId)
        {
            var response = await _httpClient.GetAsync(UserEndpoints.Get(userId));
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<UserResponse>();
            }
            return await Result<UserResponse>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult> RegisterUserAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(UserEndpoints.Register, request);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult();
            }
            return await Result.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult> ToggleUserStatusAsync(ToggleUserStatusRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(UserEndpoints.ToggleUserStatus, request);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult();
            }
            return await Result.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<UserRolesResponse>> GetRolesAsync(string userId)
        {
            var response = await _httpClient.GetAsync(UserEndpoints.GetUserRoles(userId));
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<UserRolesResponse>();
            }
            return await Result<UserRolesResponse>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(UserEndpoints.PostUserRoles, request);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<UserRolesResponse>();
            }
            return await Result<UserRolesResponse>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest model)
        {
            var response = await _httpClient.PostAsJsonAsync(UserEndpoints.ForgotPassword, model);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult();
            }
            return await Result.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(UserEndpoints.ResetPassword, request);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult();
            }
            return await Result.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<string> ExportToExcelAsync(string searchString = "")
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? UserEndpoints.Export
                : UserEndpoints.ExportFiltered(searchString));

            var data = await response.Content.ReadAsStringAsync();
            return data;

        }

        public async Task<IResult<string>> ReleaseDevice(string UserId)
        {
            var response = await _httpClient.GetAsync(UserEndpoints.ReleaseDevice(UserId));
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<string>> DeleteUser(string UserId)
        {
            var response = await _httpClient.GetAsync(UserEndpoints.Delete(UserId));
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<PaginatedResult<UserResponse>> GetPagedAsync(UserPaginatedRequest request)
        {

            var response = await _httpClient.GetAsync(UserEndpoints.GetAllPaged(request.PageNumber, request.PageSize, request.SearchString, request.Orderby));
            if (response.IsSuccessStatusCode)
            {
                return await response.ToPaginatedResult<UserResponse>();
            }
            return (PaginatedResult<UserResponse>)await PaginatedResult<UserResponse>.FailAsync($"{response.StatusCode} - Error Occured");
        }
    }
}