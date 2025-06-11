using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.UI.Shared.Endpoints
{
    public static class ProductCategoryEndpoints
    {
        // Endpoint to get paginated product categories
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString, string[] orderBy)
        {
            string url = $"api/v1/ProductCategory?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}&orderBy=";
            if (orderBy?.Any() == true)
            {
                foreach (string orderByPart in orderBy)
                {
                    url += $"{orderByPart},";
                }
                url = url[..^1]; // remove trailing comma
            }
            return url;
        }

        // Endpoint to get all product categories
        public static string GetAllData = "api/v1/ProductCategory/GetAll";

        // Endpoint to get the count of product categories
        public static string GetCount = "api/v1/ProductCategory/count";

        // Endpoint to get a specific product category by ID
        public static string GetProductCategoryById(string ProductCategoryId)
        {
            return $"api/v1/ProductCategory/{ProductCategoryId}";
        }


        // Endpoint to export filtered product categories
        public static string ExportFiltered(string searchString)
        {
            return $"{Export}?searchString={searchString}";
        }

        // Endpoint to save a product category (add or update)
        public static string Save = "api/v1/ProductCategory";

        // Endpoint to delete a product category
        public static string Delete = "api/v1/ProductCategory/Delete";

        // Endpoint to export product categories
        public static string Export = "api/v1/ProductCategory/export";
    }
}
