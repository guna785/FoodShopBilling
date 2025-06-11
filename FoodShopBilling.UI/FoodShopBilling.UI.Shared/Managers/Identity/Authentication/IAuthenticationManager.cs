using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests.Identity;
using System.Security.Claims;

namespace FoodShopBilling.UI.Shared.Managers.Identity.Authentication
{
    public interface IAuthenticationManager : IManager
    {
        Task<IResult> Login(TokenRequest model);

        Task<IResult> Logout();

        Task<string> RefreshToken();

        Task<string> TryRefreshToken();

        Task<string> TryForceRefreshToken();

        Task<ClaimsPrincipal> CurrentUser();
    }
}