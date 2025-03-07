using FoodShopBilling.Utilities.Interfaces.Common;
using FoodShopBilling.Utilities.Requests.Identity;
using FoodShopBilling.Utilities.Responses.Identity;
using FoodShopBilling.Shared.Wrapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;

namespace FoodShopBilling.Application.Interfaces.Services.Identity
{
    public interface IUserService : IService
    {
        Task<DataTablesJsonResult> GetPaginatedAsync(IDataTablesRequest request);
        Task<Result<List<UserResponse>>> GetAllAsync();
        Task<Result<int>> DeleteUser(string userId);
        Task<int> GetCountAsync();

        Task<IResult<UserResponse>> GetAsync(string userId);

        Task<IResult> RegisterAsync(RegisterRequest request, string origin);

        Task<IResult> ToggleUserStatusAsync(ToggleUserStatusRequest request);

        Task<IResult<UserRolesResponse>> GetRolesAsync(string id);

        Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request);

        Task<IResult<string>> ConfirmEmailAsync(string userId, string code);

        Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);

        Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);

        Task<string> ExportToExcelAsync(string searchString = "");
    }
}
