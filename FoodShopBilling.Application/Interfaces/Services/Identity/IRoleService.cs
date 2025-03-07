using FoodShopBilling.Utilities.Interfaces.Common;
using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Utilities.Responses.Identity;
using FoodShopBilling.Shared.Wrapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;


namespace FoodShopBilling.Application.Interfaces.Services.Identity
{
    public interface IRoleService : IService
    {
        Task<DataTablesJsonResult> GetPaginatedAsync(IDataTablesRequest request);
        Task<Result<List<RoleResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleResponse>> GetByIdAsync(int id);

        Task<Result<string>> SaveAsync(RoleRequest request);

        Task<Result<string>> DeleteAsync(int id);

        Task<Result<PermissionResponse>> GetAllPermissionsAsync(int roleId);

        Task<Result<string>> UpdatePermissionsAsync(PermissionRequest request);
    }
}
