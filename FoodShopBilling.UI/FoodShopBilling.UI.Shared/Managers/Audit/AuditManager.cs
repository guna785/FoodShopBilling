using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.UI.Shared.Endpoints;
using FoodShopBilling.UI.Shared.Extensions;
using FoodShopBilling.Utilities.Requests;
using FoodShopBilling.Utilities.Responses.Audit;
using FoodShopBilling.Utilities.Responses.Identity;

namespace FoodShopBilling.UI.Shared.Managers.Audit
{
    public class AuditManager : IAuditManager
    {
        private readonly HttpClient _httpClient;

        public AuditManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync()
        {
            var response = await _httpClient.GetAsync(AuditEndpoints.GetCurrentUserTrails);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.ToResult<IEnumerable<AuditResponse>>();
                return data;
            }
            return await Result<IEnumerable<AuditResponse>>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false)
        {
            var response = await _httpClient.GetAsync(string.IsNullOrWhiteSpace(searchString)
                ? AuditEndpoints.DownloadFile
                : AuditEndpoints.DownloadFileFiltered(searchString, searchInOldValues, searchInNewValues));
            if (response.IsSuccessStatusCode)
            {
                return await response.ToResult<string>();
            }
            return await Result<string>.FailAsync($"Error {response.StatusCode}");
        }

        public async Task<PaginatedResult<AuditResponse>> GetPaginated(AuditPagedRequest request)
        {
            var response = await _httpClient.GetAsync(AuditEndpoints.GetAllPaged(request.PageNumber, request.PageSize, request.SearchString, request.Orderby!));
            if (response.IsSuccessStatusCode)
            {
                return await response.ToPaginatedResult<AuditResponse>();
            }
            return (PaginatedResult<AuditResponse>)await PaginatedResult<AuditResponse>.FailAsync($"{response.StatusCode} - Error Occured");
        }
    }
}