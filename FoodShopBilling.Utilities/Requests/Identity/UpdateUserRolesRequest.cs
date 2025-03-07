using FoodShopBilling.Utilities.Responses.Identity;

namespace FoodShopBilling.Utilities.Requests.Identity
{
    public class UpdateUserRolesRequest
    {
        public string UserId { get; set; }
        public IList<UserRoleModel> UserRoles { get; set; }
    }
}
