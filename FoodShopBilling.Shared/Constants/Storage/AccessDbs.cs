using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Shared.Constants.Storage
{
    public static class AccessDbs
    {
        public const string StaffTable = "staff";
        public const string StudentTable = "student";
        public const string AccessDeviceTable = "accessDevice";
        public const string LocationTable = "location";
        public const string StaffCardData = "staffCardData";
        public const string StaffBiometricData = "staffBiometricData";
        public const string StaffFaceData = "staffFaceData";
        public const string StudentCardData = "studentCardData";
        public const string StudentBiometricData = "studentBiometricData";
        public const string StudentFaceData = "studentFaceData";
        public const string UserCardData = "userCardData";
        public const string UserBiometricData = "userBiometricData";
        public const string UserFaceData = "userFaceData";

        public const string LabStaffAccessDeviceStatus = "labStaffAccessDeviceStatus";
        public const string StaffAccessDeviceStatus = "staffAccessDeviceStatus";
        public const string LibraryStaffAccessDeviceStatus = "libraryStaffAccessDeviceStatus";
        public const string LabStudentAccessDeviceStatus = "labStudentAccessDeviceStatus";
        public const string LibraryStudentAccessDeviceStatus = "libraryStudentAccessDeviceStatus";
        public const string StudentAccessLog = "studentAccessLog";
        public const string StaffAccessLog = "staffAccessLog";
        public const string LibraryStudentAccessLog = "libraryStudentAccessLog";
        public const string LibraryStaffAccessLog = "libraryStaffAccessLog";
        public const string LabStudentAccessLog = "labStudentAccessLog";
        public const string LabStaffAccessLog = "labStaffAccessLog";
        public const string StudentAccessDeviceStatus = "studentAccessDeviceStatus";
        public const string SpectraStudentAccessLog = "spectraDeviceAccessLog";

        public const string CanteenStudentAccessLog = "canteenStudentAttendanceLog";
        public const string CanteenStudentAccessDeviceStatus = "canteenStudentAccessDeviceStatus";
        public const string CanteenStaffAccessLog = "canteenStaffAttendanceLog";
        public const string CanteenStaffAccessDeviceStatus = "canteenStaffAccessDeviceStatus";

        public static string InsertStudentAccessLogs(string deviceStudentApplicationTable) =>
            $"INSERT INTO {deviceStudentApplicationTable} (StudentId,UserId,idwVerifyMode,idwInOutMode,DeviceId,idwMinute," +
            "idwDay,idwHour,idwMonth,idwSecond,idwYear,idwWorkcode,CreatedBy,CreatedOn,IsDeleted,IPAddress," +
            "PunchTime,ConsumerName,LocationName,DeviceName,DeviceIpAddress,Mac,Sync) " +
            "Values (@ConsumerId,@UserId,@idwVerifyMode,@idwInOutMode,@DeviceId,@idwMinute,@idwDay,@idwHour," +
            "@idwMonth,@idwSecond,@idwYear,@idwWorkcode,@CreatedBy,@CreatedOn,@IsDeleted,@IPAddress,@PunchTime," +
            "@ConsumerName,@LocationName,@DeviceName,@DeviceIpAddress,@Mac,@Sync);";
        public static string InsertStaffAccessLogs(string deviceStaffApplicationTable) =>
            $"INSERT INTO {deviceStaffApplicationTable} (StaffId,UserId,idwVerifyMode,idwInOutMode,DeviceId,idwMinute," +
            "idwDay,idwHour,idwMonth,idwSecond,idwYear,idwWorkcode,CreatedBy,CreatedOn,IsDeleted,IPAddress," +
            "PunchTime,ConsumerName,LocationName,DeviceName,DeviceIpAddress,Mac,Sync) " +
            "Values (@ConsumerId,@UserId,@idwVerifyMode,@idwInOutMode,@DeviceId,@idwMinute,@idwDay,@idwHour," +
            "@idwMonth,@idwSecond,@idwYear,@idwWorkcode,@CreatedBy,@CreatedOn,@IsDeleted,@IPAddress,@PunchTime," +
            "@ConsumerName,@LocationName,@DeviceName,@DeviceIpAddress,@Mac,@Sync);";

        public static string GetStaffAccessDevicesStatus(string table) => $@"
            SELECT c.Id
            ,S.EmpId as UserId
            ,D.Name as AccessDeviceName
            ,c.IsActive
            ,c.CreatedBy
            ,c.CreatedOn
            ,c.LastModifiedBy
            ,c.LastModifiedOn
            ,c.IPAddress
            ,c.IsDeleted
            FROM {table} as c
            join accessDevice as D on c.AccessDeviceId = d.Id 
            join staff as S on c.StaffId = s.Id";

        public static string GetStudentAccessDevicesStatus(string table) => $@"
            SELECT c.Id
            ,S.RollNo as UserId
            ,D.Name as AccessDeviceName
            ,c.IsActive  
            ,c.CreatedBy
            ,c.CreatedOn
            ,c.LastModifiedBy
            ,c.LastModifiedOn
            ,c.IPAddress
            ,c.IsDeleted
            FROM {table} as c
            join accessDevice as D on c.AccessDeviceId = d.Id 
            join Student as S on c.StudentId = s.Id";

        public static string GetUserId(bool isStaff) => isStaff ? "StaffId" : "StudentId";
        public static string InsertAccessDeviceStatus(string table,bool isStaff) => $@"
                INSERT INTO {table} ({GetUserId(isStaff)},AccessDeviceId,IsActive,CreatedBy,CreatedOn,LastModifiedBy,LastModifiedOn,IsDeleted,IPAddress)
                VALUES (@UserId,@AccessDeviceId,@IsActive,@CreatedBy,@CreatedOn,@LastModifiedBy,@LastModifiedOn,@IsDeleted,@IPAddress)";
    }
}
