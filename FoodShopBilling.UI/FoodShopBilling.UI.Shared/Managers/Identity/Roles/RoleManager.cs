using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Utilities.Responses.Identity;
using FoodShopBilling.UI.Shared.Extensions;
using System.Net.Http.Json;
using FoodShopBilling.UI.Shared.Endpoints;
using Microsoft.Extensions.Configuration;

namespace FoodShopBilling.UI.Shared.Managers.Identity.Roles
{
    public class RoleManager : IRoleManager
    {
        private readonly HttpClient _httpClient;

        public RoleManager(HttpClient httpClient,IConfiguration configuration)
        {
            _httpClient = httpClient;
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(configuration["BaseAddress"]!);
            }
        }

        public async Task<IResult<string>> DeleteAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{RolesEndpoints.Delete}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<List<RoleResponse>>> GetRolesAsync()
        {
            var response = await _httpClient.GetAsync(RolesEndpoints.GetAll);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<List<RoleResponse>>();
            }
            return await Result<List<RoleResponse>>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<string>> SaveAsync(RoleRequest role)
        {
            var response = await _httpClient.PostAsJsonAsync(RolesEndpoints.Save, role);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<PermissionResponse>> GetPermissionsAsync(string roleId)
        {
            var response = await _httpClient.GetAsync(RolesEndpoints.GetPermissions + roleId);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<PermissionResponse>();
            }
            return await Result<PermissionResponse>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<string>> UpdatePermissionsAsync(PermissionRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(RolesEndpoints.UpdatePermissions, request);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<PaginatedResult<RoleResponse>> GetPagedAsync(RolePaginatedRequest request)
        {

            var response = await _httpClient.GetAsync(RolesEndpoints.GetAllPaged(request.PageNumber, request.PageSize, request.SearchString, request.Orderby));
            if (response.IsSuccessStatusCode)
            {
                return await response.ToPaginatedResult<RoleResponse>();
            }
            return (PaginatedResult<RoleResponse>)await PaginatedResult<RoleResponse>.FailAsync($"{response.StatusCode} - Error Occured");
        }
    }
}