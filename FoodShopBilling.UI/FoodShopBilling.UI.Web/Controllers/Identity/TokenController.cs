using Microsoft.AspNetCore.Mvc;
using FoodShopBilling.Application.Interfaces.Services;
using FoodShopBilling.Application.Interfaces.Services.Identity;
using FoodShopBilling.Utilities.Requests.Identity;

namespace FoodShopBilling.UI.Web.Controllers.Identity
{
    [Route("api/identity/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _identityService;

        public TokenController(ITokenService identityService, ICurrentUserService currentUserService)
        {
            _identityService = identityService;
        }

        /// <summary>
        /// Get Token (Email, Password)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost]
        public async Task<ActionResult> Get(TokenRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FoodShopBilling.Shared.Wrapper.Result<FoodShopBilling.Utilities.Responses.Identity.TokenResponse> response = await _identityService.LoginAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Get Token (Email, Password)
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("Mobile")]
        public async Task<ActionResult> GetMobile(TokenMobileRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FoodShopBilling.Shared.Wrapper.Result<FoodShopBilling.Utilities.Responses.Identity.MobileTokenResponse> response = await _identityService.LoginMobileAsync(model);
            return Ok(response);
        }

        /// <summary>
        /// Refresh Token
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost("refresh")]
        public async Task<ActionResult> Refresh([FromBody] RefreshTokenRequest model)
        {
            FoodShopBilling.Shared.Wrapper.Result<FoodShopBilling.Utilities.Responses.Identity.TokenResponse> response = await _identityService.GetRefreshTokenAsync(model);
            return Ok(response);
        }
    }
}
