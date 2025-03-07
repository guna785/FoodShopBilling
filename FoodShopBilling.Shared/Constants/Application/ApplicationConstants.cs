using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Shared.Constants.Application
{
    public static class ApplicationConstants
    {
        public static class SPConstants
        {
            public const string PaginatedStaffQuery = "PaginatedStaffSearch";
            public const string PaginatedStudentQuery = "PaginatedStudentSearch";
            public const string PaginatedDeviceQuery = "PaginatedDeviceSearch";
            public const string PaginatedDeviceCommandSearch = "PaginatedDeviceCommandSearch";
            public const string PaginatedDeviceOperationSearch = "PaginatedDeviceOperationSearch";
            public const string PaginatedLocationQuery = "PaginatedLocationSearch";
            public const string CacheStaffData = "CacheStaffData";
            public const string CachedStudentData = "CachedStudentData";
            public const string UserUploadDataToDevice = "UserUploadDataToDevice";
        }
        public static class SignalR
        {
            public const string HubUrl = "/signalRHub";
            public const string SendUpdateDashboard = "UpdateDashboardAsync";
            public const string ReceiveUpdateDashboard = "UpdateDashboard";
            public const string SendRegenerateTokens = "RegenerateTokensAsync";
            public const string ReceiveRegenerateTokens = "RegenerateTokens";
            public const string ReceiveChatNotification = "ReceiveChatNotification";
            public const string SendChatNotification = "ChatNotificationAsync";
            public const string ReceiveMessage = "ReceiveMessage";
            public const string SendMessage = "SendMessageAsync";

            public const string OnConnect = "OnConnectAsync";
            public const string ConnectUser = "ConnectUser";
            public const string OnDisconnect = "OnDisconnectAsync";
            public const string DisconnectUser = "DisconnectUser";
            public const string OnChangeRolePermissions = "OnChangeRolePermissions";
            public const string LogoutUsersByRole = "LogoutUsersByRole";

            public const string PingRequest = "PingRequestAsync";
            public const string PingResponse = "PingResponseAsync";

        }
        public static class Cache
        {
            public const string GetAllConsumerCacheKey = "all-consumers";
            public const string GetAllConsumerPermissionCacheKey = "all-consumers-permissions";
            public const string GetAllLocationCacheKey = "all-locations";
            public const string GetAllDeviceCacheKey = "all-devices";
            public const string GetAllToMailSettingCacheKey = "all-to-mailsettings";
            public const string GetAllStaffCacheKey = "all-staffs";
            public const string GetAllStudentCacheKey = "all-students";
            public const string GetAllDeviceGroupCacheKey = "get-device-group";
        }

        public static class MimeTypes
        {
            public const string OpenXml = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            public const string OctetStream = "application/octet-stream";
            public const string PDF = "application/pdf";
        }
    }
}
