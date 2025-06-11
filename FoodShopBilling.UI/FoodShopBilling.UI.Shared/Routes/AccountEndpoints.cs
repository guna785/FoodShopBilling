namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class AccountEndpoints
    {
        public static string Register = "api/identity/account/register";
        public static string ChangePassword(string Id) => $"api/identity/account/ChangePassword/{Id}";
        public static string UpdatePassword(string Id) => $"api/identity/account/UpdatePassword/{Id}";
        public static string UpdateProfile = "api/identity/account/updateprofile";

        public static string GetProfilePicture(string userId)
        {
            return $"api/identity/account/profile-picture/{userId}";
        }

        public static string UpdateProfilePicture(string userId)
        {
            return $"api/identity/account/profile-picture/{userId}";
        }
    }
}