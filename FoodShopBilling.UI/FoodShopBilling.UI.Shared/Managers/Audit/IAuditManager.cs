
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests;
using FoodShopBilling.Utilities.Responses.Audit;

namespace FoodShopBilling.UI.Shared.Managers.Audit
{
    public interface IAuditManager : IManager
    {
        Task<PaginatedResult<AuditResponse>> GetPaginated(AuditPagedRequest request);
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync();

        Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}