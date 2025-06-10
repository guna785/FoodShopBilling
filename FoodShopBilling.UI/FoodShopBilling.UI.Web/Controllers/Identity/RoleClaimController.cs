using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FoodShopBilling.Application.Interfaces.Services.Identity;
using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Shared.Constants.Permission;

namespace FoodShopBilling.UI.Web.Controllers.Identity
{
    [Route("api/identity/roleClaim")]
    [ApiController]
    public class RoleClaimController : ControllerBase
    {
        private readonly IRoleClaimService _roleClaimService;

        public RoleClaimController(IRoleClaimService roleClaimService)
        {
            _roleClaimService = roleClaimService;
        }

        /// <summary>
        /// Get All Role Claims(e.g. Product Create Permission)
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.RoleClaims.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            FoodShopBilling.Shared.Wrapper.Result<List<FoodShopBilling.Utilities.Responses.Identity.RoleClaimResponse>> roleClaims = await _roleClaimService.GetAllAsync();
            return Ok(roleClaims);
        }

        /// <summary>
        /// Get All Role Claims By Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.RoleClaims.View)]
        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetAllByRoleId([FromRoute] int roleId)
        {
            FoodShopBilling.Shared.Wrapper.Result<List<FoodShopBilling.Utilities.Responses.Identity.RoleClaimResponse>> response = await _roleClaimService.GetAllByRoleIdAsync(roleId);
            return Ok(response);
        }

        /// <summary>
        /// Add a Role Claim
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK </returns>
        [Authorize(Policy = Permissions.RoleClaims.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(RoleClaimRequest request)
        {
            FoodShopBilling.Shared.Wrapper.Result<string> response = await _roleClaimService.SaveAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Delete a Role Claim
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.RoleClaims.Delete)]
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            FoodShopBilling.Shared.Wrapper.Result<string> response = await _roleClaimService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
