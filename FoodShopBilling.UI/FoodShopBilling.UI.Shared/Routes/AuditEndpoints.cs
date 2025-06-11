namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class AuditEndpoints
    {
        public static string DownloadFileFiltered(string searchString, bool searchInOldValues = false, bool searchInNewValues = false)
        {
            return $"{DownloadFile}?searchString={searchString}&searchInOldValues={searchInOldValues}&searchInNewValues={searchInNewValues}";
        }
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/audits?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
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
        public static string GetCurrentUserTrails = "api/audits";
        public static string DownloadFile = "api/audits/export";
    }
}