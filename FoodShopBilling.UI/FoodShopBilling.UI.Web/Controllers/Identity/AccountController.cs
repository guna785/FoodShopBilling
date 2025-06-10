using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FoodShopBilling.Application.Interfaces.Services;
using FoodShopBilling.Application.Interfaces.Services.Account;
using FoodShopBilling.Utilities.Requests.Identity;

namespace FoodShopBilling.UI.Web.Controllers.Identity
{
    [Authorize]
    [Route("api/identity/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICurrentUserService _currentUser;

        public AccountController(IAccountService accountService, ICurrentUserService currentUser)
        {
            _accountService = accountService;
            _currentUser = currentUser;
        }

        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost(nameof(UpdateProfile))]
        public async Task<ActionResult> UpdateProfile(UpdateProfileRequest model)
        {
            FoodShopBilling.Shared.Wrapper.IResult response = await _accountService.UpdateProfileAsync(model, _currentUser.UserId);
            return Ok(response);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("ChangePassword/{Id}")]
        public async Task<ActionResult> ChangePassword(int Id, ChangePasswordRequest model)
        {
            FoodShopBilling.Shared.Wrapper.IResult response = await _accountService.ChangePasswordAsync(model, Id == 0 ? _currentUser.UserId : Id);
            return Ok(response);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("UpdatePassword/{Id}")]
        public async Task<ActionResult> UpdatePassword(int Id, UpdatePasswordRequest model)
        {
            FoodShopBilling.Shared.Wrapper.IResult response = await _accountService.UpdatePasswordAsync(model, Id == 0 ? _currentUser.UserId : Id);
            return Ok(response);
        }

        /// <summary>
        /// Get Profile picture by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Status 200 OK </returns>
        [HttpGet("profile-picture/{userId}")]
        [ResponseCache(NoStore = false, Location = ResponseCacheLocation.Client, Duration = 60)]
        public async Task<IActionResult> GetProfilePictureAsync(int userId)
        {
            return Ok(await _accountService.GetProfilePictureAsync(userId));
        }

        /// <summary>
        /// Update Profile Picture
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("profile-picture/{userId}")]
        public async Task<IActionResult> UpdateProfilePictureAsync(UpdateProfilePictureRequest request)
        {
            return Ok(await _accountService.UpdateProfilePictureAsync(request, _currentUser.UserId));
        }
    }
}
