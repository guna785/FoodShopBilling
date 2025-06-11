namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class RolesEndpoints
    {
        public static string Delete = "api/identity/role/delete";
        public static string GetAll = "api/identity/role";
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/identity/role?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
        public static string Save = "api/identity/role";
        public static string GetPermissions = "api/identity/role/permissions/";
        public static string UpdatePermissions = "api/identity/role/permissions/update";
    }
}