using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Utilities.Interfaces.Common;
using FoodShopBilling.Shared.Wrapper;

namespace FoodShopBilling.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model);
        Task<IResult> UpdatePasswordAsync(UpdatePasswordRequest model);
        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model);

        Task<IResult<string>> GetProfilePictureAsync(int userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request);
    }
}
