using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Utilities.Interfaces.Common;
using FoodShopBilling.Shared.Wrapper;

namespace FoodShopBilling.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, int userId);

        Task<IResult> UpdatePasswordAsync(UpdatePasswordRequest model, int userId);
        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, int userId);

        Task<IResult<string>> GetProfilePictureAsync(int userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, int userId);
    }
}
