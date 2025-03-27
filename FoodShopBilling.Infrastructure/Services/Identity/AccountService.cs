using FoodShopBilling.Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using FoodShopBilling.Application.Interfaces.Services;
using FoodShopBilling.Application.Interfaces.Services.Account;
using FoodShopBilling.Shared.Wrapper;
using FoodShopBilling.Utilities.Requests.Identity;

namespace FoodShopBilling.Infrastructure.Services.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUploadService _uploadService;
        private readonly IStringLocalizer<AccountService> _localizer;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUploadService uploadService,
            IStringLocalizer<AccountService> localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, int userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return await Result.FailAsync(_localizer["User Not Found."]);
            }

            IdentityResult identityResult = await _userManager.ChangePasswordAsync(
                user,
                model.OldPassword,
                model.NewPassword);
            List<string> errors = identityResult.Errors.Select(e => _localizer[e.Description].ToString()).ToList();
            return identityResult.Succeeded ? await Result.SuccessAsync() : await Result.FailAsync(errors);
        }

        public async Task<IResult> UpdateProfileAsync(UpdateProfileRequest request, int userId)
        {
            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                ApplicationUser? userWithSamePhoneNumber = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber && x.UserName != request.UserName);
                if (userWithSamePhoneNumber != null)
                {
                    return await Result.FailAsync(string.Format(_localizer["Phone number {0} is already used."], request.PhoneNumber));
                }
            }

            ApplicationUser? userWithSameEmail = await _userManager!.Users!.Where(x => x.Email == request.Email && x.UserName != request.UserName)!.FirstOrDefaultAsync()!;
            if (userWithSameEmail == null || userWithSameEmail.Id == userId)
            {
                ApplicationUser? user = await _userManager.FindByNameAsync(request.UserName);
                if (user == null)
                {
                    return await Result.FailAsync(_localizer["User Not Found."]);
                }
                user.Name = request.Name;
                user.Email = request.Email;
                user.PhoneNumber = request.PhoneNumber;
                string phoneNumber = await _userManager.GetPhoneNumberAsync(user);
                if (request.PhoneNumber != phoneNumber)
                {
                    IdentityResult setPhoneResult = await _userManager.SetPhoneNumberAsync(user, request.PhoneNumber);
                }
                IdentityResult identityResult = await _userManager.UpdateAsync(user);
                List<string> errors = identityResult.Errors.Select(e => _localizer[e.Description].ToString()).ToList();
                await _signInManager.RefreshSignInAsync(user);
                return identityResult.Succeeded ? await Result.SuccessAsync() : await Result.FailAsync(errors);
            }
            else
            {
                return await Result.FailAsync(string.Format(_localizer["Email {0} is already used."], request.Email));
            }
        }

        public async Task<IResult<string>> GetProfilePictureAsync(int userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return await Result<string>.FailAsync(_localizer["User Not Found"]);
            }
            byte[] bytes = await File.ReadAllBytesAsync(user.ProfilePictureDataUrl!);
            string data = Convert.ToBase64String(bytes);
            return await Result<string>.SuccessAsync(data: data);
        }

        public async Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, int userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return await Result<string>.FailAsync(message: _localizer["User Not Found"]);
            }

            string filePath = _uploadService.UploadAsync(request);
            user.ProfilePictureDataUrl = filePath;
            IdentityResult identityResult = await _userManager.UpdateAsync(user);
            List<string> errors = identityResult.Errors.Select(e => _localizer[e.Description].ToString()).ToList();
            return identityResult.Succeeded ? await Result<string>.SuccessAsync(data: filePath) : await Result<string>.FailAsync(errors);
        }

        public async Task<IResult> UpdatePasswordAsync(UpdatePasswordRequest model, int userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return await Result.FailAsync(_localizer["User Not Found."]);
            }
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
            IdentityResult identityResult = await _userManager.UpdateAsync(user);
            List<string> errors = identityResult.Errors.Select(e => _localizer[e.Description].ToString()).ToList();
            return identityResult.Succeeded ? await Result.SuccessAsync() : await Result.FailAsync(errors);
        }
    }
}
