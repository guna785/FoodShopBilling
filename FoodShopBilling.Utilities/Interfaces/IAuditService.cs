using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Responses.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Utilities.Interfaces
{
    public interface IAuditService
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserProfileTrailsAsync(string userId);

        Task<DataTablesJsonResult> GetPaginatedAsync(IDataTablesRequest request);
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync(string userId);

        Task<IResult<string>> ExportToExcelAsync(string userId, string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}
