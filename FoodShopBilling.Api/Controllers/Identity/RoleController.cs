using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FoodShopBilling.Application.Interfaces.Services.Identity;
using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Shared.Constants.Permission;

namespace FoodShopBilling.Api.Controllers.Identity
{
    [Route("api/identity/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Get All Roles (basic, admin etc.)
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Roles.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            FoodShopBilling.Shared.Wrapper.Result<List<FoodShopBilling.Utilities.Responses.Identity.RoleResponse>> roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

        /// <summary>
        /// Add a Role
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Roles.Create)]
        [HttpPost]
        public async Task<IActionResult> Post(RoleRequest request)
        {
            FoodShopBilling.Shared.Wrapper.Result<string> response = await _roleService.SaveAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Delete a Role
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize(Policy = Permissions.Roles.Delete)]
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            FoodShopBilling.Shared.Wrapper.Result<string> response = await _roleService.DeleteAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Get Permissions By Role Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>Status 200 Ok</returns>
        [Authorize(Policy = Permissions.RoleClaims.View)]
        [HttpGet("permissions/{roleId}")]
        public async Task<IActionResult> GetPermissionsByRoleId([FromRoute] int roleId)
        {
            FoodShopBilling.Shared.Wrapper.Result<FoodShopBilling.Utilities.Responses.Identity.PermissionResponse> response = await _roleService.GetAllPermissionsAsync(roleId);
            return Ok(response);
        }

        /// <summary>
        /// Edit a Role Claim
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Policy = Permissions.RoleClaims.Edit)]
        [HttpPost("permissions/update")]
        public async Task<IActionResult> Update(PermissionRequest model)
        {
            FoodShopBilling.Shared.Wrapper.Result<string> response = await _roleService.UpdatePermissionsAsync(model);
            return Ok(response);
        }
    }
}
