using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Shared.Constants.Permission
{
    public static class Permissions
    {

        [DisplayName("Product")]
        [Description("Product Permissions")]
        public static class Product
        {
            public const string View = "Permissions.Product.View";
            public const string Create = "Permissions.Product.Create";
            public const string BulkUpload = "Permissions.Product.BulkUpload";
            public const string Edit = "Permissions.Product.Edit";
            public const string Delete = "Permissions.Product.Delete";
            public const string Export = "Permissions.Product.Export";
            public const string Search = "Permissions.Product.Search";
        }

        [DisplayName("ProductCategory")]
        [Description("ProductCategory Permissions")]
        public static class ProductCategory
        {
            public const string View = "Permissions.ProductCategory.View";
            public const string Create = "Permissions.ProductCategory.Create";
            public const string Edit = "Permissions.ProductCategory.Edit";
            public const string Delete = "Permissions.ProductCategory.Delete";
            public const string Export = "Permissions.ProductCategory.Export";
            public const string Search = "Permissions.ProductCategory.Search";
            public const string Import = "Permissions.Sales.Import";
        }

        [DisplayName("Sales")]
        [Description("Sales Permissions")]
        public static class Sales
        {
            public const string View = "Permissions.Sales.View";
            public const string Create = "Permissions.Sales.Create";
            public const string Edit = "Permissions.Sales.Edit";
            public const string Delete = "Permissions.Sales.Delete";
            public const string Export = "Permissions.Sales.Export";
            public const string Search = "Permissions.Sales.Search";
            public const string Import = "Permissions.Sales.Import";
        }

        [DisplayName("Users")]
        [Description("Users Permissions")]
        public static class Users
        {
            public const string View = "Permissions.Users.View";
            public const string Create = "Permissions.Users.Create";
            public const string Edit = "Permissions.Users.Edit";
            public const string Delete = "Permissions.Users.Delete";
            public const string Export = "Permissions.Users.Export";
            public const string Search = "Permissions.Users.Search";
        }

        [DisplayName("Roles")]
        [Description("Roles Permissions")]
        public static class Roles
        {
            public const string View = "Permissions.Roles.View";
            public const string Create = "Permissions.Roles.Create";
            public const string Edit = "Permissions.Roles.Edit";
            public const string Delete = "Permissions.Roles.Delete";
            public const string Search = "Permissions.Roles.Search";
        }

        [DisplayName("Role Claims")]
        [Description("Role Claims Permissions")]
        public static class RoleClaims
        {
            public const string View = "Permissions.RoleClaims.View";
            public const string Create = "Permissions.RoleClaims.Create";
            public const string Edit = "Permissions.RoleClaims.Edit";
            public const string Delete = "Permissions.RoleClaims.Delete";
            public const string Search = "Permissions.RoleClaims.Search";
        }

        [DisplayName("Communication")]
        [Description("Communication Permissions")]
        public static class Communication
        {
            public const string Chat = "Permissions.Communication.Chat";
        }

        [DisplayName("Preferences")]
        [Description("Preferences Permissions")]
        public static class Preferences
        {
            public const string ChangeLanguage = "Permissions.Preferences.ChangeLanguage";

            //TODO - add permissions
        }

        [DisplayName("Dashboards")]
        [Description("Dashboards Permissions")]
        public static class Dashboards
        {
            public const string View = "Permissions.Dashboards.View";
        }

        [DisplayName("Hangfire")]
        [Description("Hangfire Permissions")]
        public static class Hangfire
        {
            public const string View = "Permissions.Hangfire.View";
        }

        [DisplayName("Audit Trails")]
        [Description("Audit Trails Permissions")]
        public static class AuditTrails
        {
            public const string View = "Permissions.AuditTrails.View";
            public const string Export = "Permissions.AuditTrails.Export";
            public const string Search = "Permissions.AuditTrails.Search";
        }

        /// <summary>
        /// Returns a list of Permissions.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetRegisteredPermissions()
        {
            List<string> permissions = new();
            foreach (FieldInfo? prop in typeof(Permissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
            {
                object? propertyValue = prop.GetValue(null);
                if (propertyValue is not null)
                {
                    permissions.Add(propertyValue.ToString()!);
                }
            }
            return permissions;
        }
    }
}
