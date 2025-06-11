using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Utilities.Responses.Identity;
using FoodShopBilling.UI.Shared.Extensions;
using System.Net.Http.Json;
using FoodShopBilling.UI.Shared.Endpoints;
using Microsoft.Extensions.Configuration;

namespace FoodShopBilling.UI.Shared.Managers.Identity.RoleClaims
{
    public class RoleClaimManager : IRoleClaimManager
    {
        private readonly HttpClient _httpClient;

        public RoleClaimManager(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(configuration["BaseAddress"]!);
            }
        }

        public async Task<IResult<string>> DeleteAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{RoleClaimsEndpoints.Delete}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync()
        {
            var response = await _httpClient.GetAsync(RoleClaimsEndpoints.GetAll);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<List<RoleClaimResponse>>();
            }
            return await Result<List<RoleClaimResponse>>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId)
        {
            var response = await _httpClient.GetAsync($"{RoleClaimsEndpoints.GetAll}/{roleId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<List<RoleClaimResponse>>();
            }
            return await Result<List<RoleClaimResponse>>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<string>> SaveAsync(RoleClaimRequest role)
        {
            var response = await _httpClient.PostAsJsonAsync(RoleClaimsEndpoints.Save, role);
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }
    }
}