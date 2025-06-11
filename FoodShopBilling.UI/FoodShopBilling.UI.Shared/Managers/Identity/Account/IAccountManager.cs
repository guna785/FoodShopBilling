

using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests.Identity;

namespace FoodShopBilling.UI.Shared.Managers.Identity.Account
{
    public interface IAccountManager : IManager
    {
        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model,  string Id);
        Task<IResult> UpdatePasswordAsync(UpdatePasswordRequest model, string Id);
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}