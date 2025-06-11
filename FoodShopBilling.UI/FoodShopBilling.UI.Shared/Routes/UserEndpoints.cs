namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class UserEndpoints
    {
        public const string GetAll = "api/identity/user";
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/identity/user?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                foreach (string orderByPart in orderBy)
                {
                    url += $"{orderByPart},";
                }
                url = url[..^1]; // loose training ,
            }
            return url;
        }
        public static string Get(string userId)
        {
            return $"api/identity/user/{userId}";
        }

        public static string GetUserRoles(string userId)
        {
            return $"api/identity/user/roles/{userId}";
        }

        public static string ReleaseDevice(string userId) => $"api/identity/user/ReleaseDevice/{userId}";
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        public const string Export = "api/identity/user/export";
        public const string PostUserRoles = "api/identity/user/roles";
        public static string Delete(string Id) => $"api/identity/user/delete/{Id}";
        public const string Register = "api/identity/user";
        public const string ToggleUserStatus = "api/identity/user/toggle-status";
        public const string ForgotPassword = "api/identity/user/forgot-password";
        public const string ResetPassword = "api/identity/user/reset-password";
    }
}