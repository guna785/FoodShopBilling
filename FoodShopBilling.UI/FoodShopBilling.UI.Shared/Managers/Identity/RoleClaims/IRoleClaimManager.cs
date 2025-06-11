
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Utilities.Responses.Identity;

namespace FoodShopBilling.UI.Shared.Managers.Identity.RoleClaims
{
    public interface IRoleClaimManager : IManager
    {
        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

        Task<IResult<string>> SaveAsync(RoleClaimRequest role);

        Task<IResult<string>> DeleteAsync(string id);
    }
}