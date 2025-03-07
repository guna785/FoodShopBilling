using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopBilling.Shared.Constants.Storage
{
    public static class SqlConstants
    {
        public static string AllMonthlyUserLog(string dbName, string userDb, string userId, int year, int month,string empId)
        {
            int lastday = DateTime.DaysInMonth(year, month);
            return $" DECLARE @StartDate DATE = '{year}-{month}-01'; " +
                $" DECLARE @EndDate DATE = '{year}-{month}-{lastday}';" +
            $" WITH CalendarDays AS (  " +
            $"   SELECT @StartDate AS CalendarDay " +
            $"          UNION ALL " +
            $"          SELECT DATEADD(DAY, 1, CalendarDay)" +
            $"          FROM CalendarDays  " +
            $"          WHERE CalendarDay < @EndDate ) " +
            $" SELECT FORMAT( C.CalendarDay,'dd ddd') as CalenderDay,Min(S.{empId}) as UserId,Min(S.Name) as Name, " +
            $" CASE WHEN  Min(S.Gender) =0 THEN 'MALE' ELSE 'FEMALE' END as Gender, " +
            $" CASE WHEN  MIN(L.PunchTime) is NUll THEN 'A' ELSE  " +
            $"      CASE WHEN (DATEName(DW, Min(L.PunchTime))='Saturday' or DATEName(DW, Min(L.PunchTime))='Sunday') THEN Concat('PW (',FORMAT(Min(L.PunchTime),'hh:mm:ss tt'),' - ',FORMAT(Min(L.PunchTime),'hh:mm:ss tt'),' )') ELSE  Concat('PW (',FORMAT(Min(L.PunchTime),'hh:mm:ss tt'),' - ',FORMAT(Max(L.PunchTime),'hh:mm:ss tt') ,' )') END " +
            $"      END as Attendance " +
            $" FROM CalendarDays as C " +
            $" Cross JOIN {userDb} as S " +
            $" LEFT JOIN {dbName} as L on ( CAST(C.CalendarDay AS DATE) =CAST(L.PunchTime AS DATE) and S.Id =L.{userId}) " +
            $" GROUP By C.CalendarDay, S.Id " +
            $" ORDER BY C.CalendarDay " +
            $" OPTION (MAXRECURSION 0)";
        }

        public static string AllUserLogReport(string dbName, string userId, int deviceId) => $"SELECT S.EmpId as UserId,S.Name  as UserName,S.Department, " +
            $"  CASE WHEN S.Gender=0 then 'Male' else 'Female' end as Gender,S.UserType, " +
            $"  L.DeviceName,L.LocationName,L.PunchTime FROM staff as S " +
            $"  JOIN {dbName} as L on S.Id=L.{userId} " +
            $"  Where L.PunchTime between @fromDate and @todate " +
             (deviceId > 0 ? $" and L.DeviceId = {deviceId}" : "") +
            $"  Order by L.PunchTime desc";
        public static string DailySpectraLogReport() => $"SELECT RollNo as UserId, StudentName as Name,CAST(PunchTime AS DATE) as PunchDate, " +
            $"  MIN(CourseCode)+' : '+ MIN(DeviceName) +'  '+ FORMAT(MIN(PunchTime), 'hh:mm:ss tt') + ' - ' + MAX(CourseCode)+' : '+ MAX(DeviceName) +' - '+  FORMAT(MAX(PunchTime), 'hh:mm:ss tt') AS FirstLastPunchTime, " +
            $"  STRING_AGG(CourseCode +' '+ DeviceName +' - '+ FORMAT(PunchTime, 'hh:mm:ss tt'), ' , ') AS PunchRecords" +
            $"  FROM spectraDeviceAccessLog  " +
            $"  WHERE CAST(PunchTime AS DATE) =CAST(@SelectDate AS DATE)" +
            $"  GROUP BY StudentName,RollNo, CAST(PunchTime AS DATE) " +
            $"  ORDER BY CAST(PunchTime AS DATE)";
        public static string DailyUserLogReport(string dbName, int deviceId) => $"SELECT UserId as UserId, ConsumerName as Name,CAST(PunchTime AS DATE) as PunchDate," +
            $" MIN(DeviceName) +'  '+ FORMAT(MIN(PunchTime), 'hh:mm:ss tt') + ' - ' +  MAX(DeviceName) +' - '+  FORMAT(MAX(PunchTime), 'hh:mm:ss tt') AS FirstLastPunchTime," +
            $" STRING_AGG(DeviceName +' - '+ FORMAT(PunchTime, 'hh:mm:ss tt'), ' , ') AS PunchRecords " +
            $" FROM {dbName}    " +
            $" WHERE CAST(PunchTime AS DATE) =CAST(@SelectDate AS DATE) " +
             (deviceId > 0 ? $" and DeviceId = {deviceId}" : "") +
            $" GROUP BY ConsumerName,UserId, CAST(PunchTime AS DATE) " +
            $" ORDER BY CAST(PunchTime AS DATE)";
        public static string SpectraUserFingers() =>
            " SELECT B.StudentId as sUserId,S.Name as sName,S.RollNo as EnrollNo, B.Finger,B.Quality,B.StudentCard as CardData,1 as UserType FROM spectraBiometricData B " +
            " INNER JOIN Student as S ON B.StudentId = S.Id " +
            " WHERE S.IsActive=@IsActive " +
            " UNION ALL " +
            " SELECT B.StaffId as sUserId,S.Name as sName,S.EmpId as EnrollNo, B.Finger,B.Quality,B.StaffCard as CardData,2 as UserType FROM spectraStaffBiometricData B  " +
            " INNER JOIN staff as S ON B.StaffId = S.Id " +
            " WHERE S.IsActive=@IsActive ";
        public static string StaffDeviceStatusUpdate(string deviceStatusDB, int exceptionalDeviceId = 0)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"DECLARE @DeviceID as INT; ");
            stringBuilder.AppendLine($"declare @msg varchar(max) ");
            stringBuilder.AppendLine($"DECLARE @DeviceCursor as CURSOR; ");
            stringBuilder.AppendLine($"SET @DeviceCursor = CURSOR FOR select Id from accessDevice where ApplicationType=@ApplicationType; ");
            stringBuilder.AppendLine($" OPEN @DeviceCursor; ");
            stringBuilder.AppendLine($" FETCH NEXT FROM @DeviceCursor INTO @DeviceID;   ");
            stringBuilder.AppendLine($"    WHILE @@FETCH_STATUS = 0 ");
            stringBuilder.AppendLine($"       BEGIN\r\n         ");
            stringBuilder.AppendLine($"         IF EXISTS (SELECT * FROM {deviceStatusDB} WHERE StaffId = @StaffId AND AccessDeviceId = @DeviceID) ");
            stringBuilder.AppendLine($"            BEGIN ");
            stringBuilder.AppendLine($"               IF @DeviceID={exceptionalDeviceId} ");
            stringBuilder.AppendLine($"                  BEGIN ");
            stringBuilder.AppendLine($"                    UPDATE {deviceStatusDB} SET IsActive=0 WHERE  StaffId = @StaffId AND AccessDeviceId = @DeviceID; ");
            stringBuilder.AppendLine($"                  END ");
            stringBuilder.AppendLine($"               ELSE ");
            stringBuilder.AppendLine($"                  BEGIN");
            stringBuilder.AppendLine($"                    UPDATE {deviceStatusDB} SET IsActive=1 WHERE  StaffId = @StaffId AND AccessDeviceId = @DeviceID; ");
            stringBuilder.AppendLine($"                  END ");
            stringBuilder.AppendLine($"            END");
            stringBuilder.AppendLine($"         ELSE ");
            stringBuilder.AppendLine($"            BEGIN ");
            stringBuilder.AppendLine($"                IF @DeviceID={exceptionalDeviceId} ");
            stringBuilder.AppendLine($"                   BEGIN ");
            stringBuilder.AppendLine($"                      INSERT INTO {deviceStatusDB} (StaffId,AccessDeviceId,CreatedBy,CreatedOn,IsActive,IPAddress,IsDeleted) VALUES (@StaffId,@DeviceID,'admin','10/18/2023',0,'10.23.0.24',0); ");
            stringBuilder.AppendLine($"                   END ");
            stringBuilder.AppendLine($"                ELSE  ");
            stringBuilder.AppendLine($"                   BEGIN ");
            stringBuilder.AppendLine($"                      INSERT INTO {deviceStatusDB} (StaffId,AccessDeviceId,CreatedBy,CreatedOn,IsActive,IPAddress,IsDeleted) VALUES (@StaffId,@DeviceID,'admin','10/18/2023',0,'10.23.0.24',0); ");
            stringBuilder.AppendLine($"                   END ");
            stringBuilder.AppendLine($"             END ");
            stringBuilder.AppendLine($"        FETCH NEXT FROM @DeviceCursor INTO @DeviceID; ");
            stringBuilder.AppendLine($"      END");
            return stringBuilder.ToString();
        }
        public static string StudentDeviceStatusUpdate(string deviceStatusDB, int exceptionalDeviceId = 0)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"DECLARE @DeviceID as INT; ");
            stringBuilder.AppendLine($"declare @msg varchar(max) ");
            stringBuilder.AppendLine($"DECLARE @DeviceCursor as CURSOR; ");
            stringBuilder.AppendLine($"SET @DeviceCursor = CURSOR FOR select Id from accessDevice where ApplicationType=@ApplicationType; ");
            stringBuilder.AppendLine($" OPEN @DeviceCursor; ");
            stringBuilder.AppendLine($" FETCH NEXT FROM @DeviceCursor INTO @DeviceID;   ");
            stringBuilder.AppendLine($"    WHILE @@FETCH_STATUS = 0 ");
            stringBuilder.AppendLine($"       BEGIN\r\n         ");
            stringBuilder.AppendLine($"         IF EXISTS (SELECT * FROM {deviceStatusDB} WHERE StudentId = @StudentId AND AccessDeviceId = @DeviceID) ");
            stringBuilder.AppendLine($"            BEGIN ");
            stringBuilder.AppendLine($"                PRINT 'Already Exists' ");           
            stringBuilder.AppendLine($"            END");
            stringBuilder.AppendLine($"         ELSE ");
            stringBuilder.AppendLine($"            BEGIN ");
            stringBuilder.AppendLine($"                IF @DeviceID={exceptionalDeviceId} ");
            stringBuilder.AppendLine($"                   BEGIN ");
            stringBuilder.AppendLine($"                      INSERT INTO {deviceStatusDB} (StudentId,AccessDeviceId,CreatedBy,CreatedOn,IsActive,IPAddress,IsDeleted) VALUES (@StudentId,@DeviceID,'admin','10/18/2023',0,'10.23.0.24',0); ");
            stringBuilder.AppendLine($"                   END ");
            stringBuilder.AppendLine($"                ELSE  ");
            stringBuilder.AppendLine($"                   BEGIN ");
            stringBuilder.AppendLine($"                      INSERT INTO {deviceStatusDB} (StudentId,AccessDeviceId,CreatedBy,CreatedOn,IsActive,IPAddress,IsDeleted) VALUES (@StudentId,@DeviceID,'admin','10/18/2023',0,'10.23.0.24',0); ");
            stringBuilder.AppendLine($"                   END ");
            stringBuilder.AppendLine($"             END ");
            stringBuilder.AppendLine($"        FETCH NEXT FROM @DeviceCursor INTO @DeviceID; ");
            stringBuilder.AppendLine($"      END");
            return stringBuilder.ToString();
        }

        public static string RegistrationDeviceStatusUpdate(string deviceStaffStatusDb, string deviceStudentStatusDb, int exceptionalDeviceId = 0)
        {
            return $" DECLARE @DeviceID as INT; " +
                $" DECLARE @DeviceCursor as CURSOR; " +
                $" SET @DeviceCursor = CURSOR FOR select Id from accessDevice where ApplicationType=@ApplicationType; " +
                $" OPEN @DeviceCursor; " +
                $" FETCH NEXT FROM @DeviceCursor INTO @DeviceID;  " +
                $"    WHILE @@FETCH_STATUS = 0 " +
                $"      BEGIN  " +
                $"         INSERT INTO {deviceStaffStatusDb} (StaffId,AccessDeviceId,IsActive,CreatedBy,CreatedOn,IsDeleted) " +
                $"                SELECT Id as StaffId,@DeviceID as AccessDeviceId,(CASE WHEN @DeviceID={exceptionalDeviceId} THEN 0 ELSE 1 END) as IsActive, 'admin' as CreatedBy,CURRENT_TIMESTAMP as CreatedOn, 0 as IsDeleted " +
                $"                  FROM staff  as S  " +
                $"                    WHERE NOT Exists (SELECT Id FROM {deviceStaffStatusDb} WHERE StaffId=S.Id and AccessDeviceId=@DeviceID);  " +
                $"         INSERT INTO  {deviceStudentStatusDb} (StudentId,AccessDeviceId,IsActive,CreatedBy,CreatedOn,IsDeleted)  " +
                $"                SELECT Id as StaffId,@DeviceID as AccessDeviceId,(CASE WHEN @DeviceID={exceptionalDeviceId} THEN 0 ELSE 1 END) as IsActive, 'admin' as CreatedBy,CURRENT_TIMESTAMP as CreatedOn, 0 as IsDeleted  " +
                $"                   FROM Student as S  " +
                $"                     WHERE NOT Exists (SELECT Id FROM {deviceStudentStatusDb} WHERE StudentId=S.Id and AccessDeviceId=@DeviceID); " +
                $"  FETCH NEXT FROM @DeviceCursor INTO @DeviceID;  " +
                $"  END ";
        }
    }
}
