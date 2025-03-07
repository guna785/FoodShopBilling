namespace FoodShopBilling.Utilities.Requests.Identity
{
    public class PermissionRequest
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public IList<RoleClaimRequest> RoleClaims { get; set; }
    }
}
