using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShopBilling.Infra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class push : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentBiometricData");

            migrationBuilder.DropTable(
                name: "studentCardData");

            migrationBuilder.DropTable(
                name: "studentFaceData");

            migrationBuilder.AddColumn<string>(
                name: "RegYear",
                table: "studentCourse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "currentSem",
                table: "studentCourse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sync",
                table: "studentAccessLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dept",
                table: "student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Finger",
                table: "spectraStaffBiometricData",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "deviceUserGroup",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AttPhotoStamp",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BaudRate",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComPort",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommKey",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectionType",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceActivationCode",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceDirection",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DownLoadType",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastLogDate",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogDownloadDate",
                table: "accessDevice",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastPing",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpStamp",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionStamp",
                table: "accessDevice",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegYear",
                table: "studentCourse");

            migrationBuilder.DropColumn(
                name: "currentSem",
                table: "studentCourse");

            migrationBuilder.DropColumn(
                name: "Sync",
                table: "studentAccessLog");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "student");

            migrationBuilder.DropColumn(
                name: "Dept",
                table: "student");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "deviceUserGroup");

            migrationBuilder.DropColumn(
                name: "AttPhotoStamp",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "BaudRate",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "ComPort",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "CommKey",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "ConnectionType",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "DeviceActivationCode",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "DeviceDirection",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "DownLoadType",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "LastLogDate",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "LastLogDownloadDate",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "LastPing",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "OpStamp",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "accessDevice");

            migrationBuilder.DropColumn(
                name: "TransactionStamp",
                table: "accessDevice");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Finger",
                table: "spectraStaffBiometricData",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "studentBiometricData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    bEnabled = table.Column<bool>(type: "bit", nullable: false),
                    iFlag = table.Column<int>(type: "int", nullable: false),
                    iPrivilege = table.Column<int>(type: "int", nullable: false),
                    iTmpLength = table.Column<int>(type: "int", nullable: false),
                    idwFingerIndex = table.Column<int>(type: "int", nullable: false),
                    sName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sTmpData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sdwEnrollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentBiometricData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentCardData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    bEnabled = table.Column<bool>(type: "bit", nullable: false),
                    iPrivilege = table.Column<int>(type: "int", nullable: false),
                    sCardnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sdwEnrollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentCardData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentFaceData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    aiData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bEnabled = table.Column<bool>(type: "bit", nullable: false),
                    iFaceIndex = table.Column<int>(type: "int", nullable: false),
                    iLength = table.Column<int>(type: "int", nullable: false),
                    iPrivilege = table.Column<int>(type: "int", nullable: false),
                    sName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sTmpData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sUserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentFaceData", x => x.Id);
                });
        }
    }
}
