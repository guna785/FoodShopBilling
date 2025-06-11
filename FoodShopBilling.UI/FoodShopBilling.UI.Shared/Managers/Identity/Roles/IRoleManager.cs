using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Utilities.Responses.Identity;

namespace FoodShopBilling.UI.Shared.Managers.Identity.Roles
{
    public interface IRoleManager : IManager
    {
        Task<PaginatedResult<RoleResponse>> GetPagedAsync(RolePaginatedRequest request);
        Task<IResult<List<RoleResponse>>> GetRolesAsync();

        Task<IResult<string>> SaveAsync(RoleRequest role);

        Task<IResult<string>> DeleteAsync(string id);

        Task<IResult<PermissionResponse>> GetPermissionsAsync(string roleId);

        Task<IResult<string>> UpdatePermissionsAsync(PermissionRequest request);
    }
}