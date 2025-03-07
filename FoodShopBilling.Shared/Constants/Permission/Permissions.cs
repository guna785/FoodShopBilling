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
        [DisplayName("Reporting")]
        [Description("Reporting Permissions")]
        public static class Reporting
        {
            public const string View = "Permissions.Reporting.View";
            public const string DailyReport = "Permissions.Reporting.DailyReport";
            public const string NotPunched = "Permissions.Reporting.NotPunched";
            public const string OverAllReporting = "Permissions.Reporting.OverAllReporting";
        }
        [DisplayName("ToMailSetting")]
        [Description("ToMailSetting Permissions")]
        public static class ToMailSetting
        {
            public const string View = "Permissions.ToMailSetting.View";
            public const string Edit = "Permissions.ToMailSetting.Edit";
            public const string Create = "Permissions.ToMailSetting.Create";
            public const string Delete = "Permissions.ToMailSetting.Delete";
            public const string Export = "Permissions.ToMailSetting.Export";
            public const string Search = "Permissions.ToMailSetting.Search";
        }
        [DisplayName("AccessLog")]
        [Description("AccessLog Permissions")]
        public static class AccessLog
        {
            public const string View = "Permissions.AccessLog.View";
            public const string Create = "Permissions.AccessLog.Create";
            public const string Delete = "Permissions.AccessLog.Delete";
            public const string Export = "Permissions.AccessLog.Export";
            public const string Search = "Permissions.AccessLog.Search";
            public const string DownloadLogs = "Permissions.AccessLog.DownloadLogs";
        }

        [DisplayName("Staff")]
        [Description("Staff Permissions")]
        public static class Staff
        {
            public const string View = "Permissions.Staff.View";
            public const string Create = "Permissions.Staff.Create";
            public const string BulkUpload = "Permissions.Staff.BulkUpload";
            public const string Edit = "Permissions.Staff.Edit";
            public const string Delete = "Permissions.Staff.Delete";
            public const string Export = "Permissions.Staff.Export";
            public const string Search = "Permissions.Staff.Search";
            public const string Profile = "Permissions.Staff.Profile";
            public const string Enable = "Permissions.Staff.Enable";
            public const string EnrollUser = "Permissions.Staff.EnrollUser";
            public const string SpectraScanFinger = "Permissions.Staff.SpectraScanFinger";
            public const string SpectraPushFinger = "Permissions.Staff.SpectraPushFinger";
        }
        [DisplayName("Student")]
        [Description("Student Permissions")]
        public static class Student
        {
            public const string View = "Permissions.Student.View";
            public const string Create = "Permissions.Student.Create";
            public const string BulkUpload = "Permissions.Student.BulkUpload";
            public const string Edit = "Permissions.Student.Edit";
            public const string Delete = "Permissions.Student.Delete";
            public const string Export = "Permissions.Student.Export";
            public const string Search = "Permissions.Student.Search";
            public const string Profile = "Permissions.Staff.Profile";
            public const string Enable = "Permissions.Staff.Enable";
            public const string EnrollUser = "Permissions.Staff.EnrollUser";
            public const string SpectraScanFinger = "Permissions.Staff.SpectraScanFinger";
            public const string SpectraPushFinger = "Permissions.Staff.SpectraPushFinger";
        }
        [DisplayName("UserGroup")]
        [Description("UserGroup Permissions")]
        public static class UserGroup
        {
            public const string View = "Permissions.UserGroup.View";
            public const string Create = "Permissions.UserGroup.Create";
            public const string BulkUpload = "Permissions.UserGroup.BulkUpload";
            public const string Edit = "Permissions.UserGroup.Edit";
            public const string Delete = "Permissions.UserGroup.Delete";
            public const string Export = "Permissions.UserGroup.Export";
            public const string Search = "Permissions.UserGroup.Search";
            public const string MapStaffs = "Permissions.UserGroup.MapStaffs";
            public const string MapStudents = "Permissions.UserGroup.MapStudents";
            public const string MapDevices = "Permissions.UserGroup.MapDevices";
        }

        [DisplayName("AccessDevice")]
        [Description("AccessDevice Permissions")]
        public static class AccessDevice
        {
            public const string View = "Permissions.AccessDevice.View";
            public const string Create = "Permissions.AccessDevice.Create";
            public const string Edit = "Permissions.AccessDevice.Edit";
            public const string Delete = "Permissions.AccessDevice.Delete";
            public const string Export = "Permissions.AccessDevice.Export";
            public const string Search = "Permissions.AccessDevice.Search";
            public const string MasterDownload = "Permissions.AccessDevice.MasterDownload";
            public const string MasterPush = "Permissions.AccessDevice.MasterPush";
            public const string DevicePush = "Permissions.AccessDevice.DevicePush";
            public const string ControllerSetup = "Permissions.AccessDevice.ControllerSetup";
            public const string FactoryReset = "Permissions.AccessDevice.FactoryReset";
            public const string CourseSync = "Permissions.AccessDevice.CourseSync";
            public const string PushDataToSpectraDevice = "Permissions.AccessDevice.PushDataToSpectraDevice";
        }

        [DisplayName("Locations")]
        [Description("Locations Permissions")]
        public static class Location
        {
            public const string View = "Permissions.Location.View";
            public const string Create = "Permissions.Location.Create";
            public const string Edit = "Permissions.Location.Edit";
            public const string Delete = "Permissions.Location.Delete";
            public const string Export = "Permissions.Location.Export";
            public const string Search = "Permissions.Location.Search";
            public const string Import = "Permissions.Location.Import";
            public const string MasterPush = "Permissions.Location.MasterPush";
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
