using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShopBilling.Infra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AuditTrails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationType = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "serviceNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    ViewedUsers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationType = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceNotification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegSem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfCompletion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CanteenIsActive = table.Column<bool>(type: "bit", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    IsLocationChanged = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentBiometricData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sdwEnrollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iPrivilege = table.Column<int>(type: "int", nullable: false),
                    bEnabled = table.Column<bool>(type: "bit", nullable: false),
                    idwFingerIndex = table.Column<int>(type: "int", nullable: false),
                    sTmpData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iTmpLength = table.Column<int>(type: "int", nullable: false),
                    iFlag = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    sdwEnrollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iPrivilege = table.Column<int>(type: "int", nullable: false),
                    bEnabled = table.Column<bool>(type: "bit", nullable: false),
                    sCardnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentCardData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentCourse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentFaceData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iPrivilege = table.Column<int>(type: "int", nullable: false),
                    bEnabled = table.Column<bool>(type: "bit", nullable: false),
                    iFaceIndex = table.Column<int>(type: "int", nullable: false),
                    sTmpData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aiData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iLength = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentFaceData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToMailSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendingType = table.Column<int>(type: "int", nullable: false),
                    ApplicationType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToMailSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userBiometricData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sdwEnrollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iPrivilege = table.Column<int>(type: "int", nullable: false),
                    bEnabled = table.Column<bool>(type: "bit", nullable: false),
                    idwFingerIndex = table.Column<int>(type: "int", nullable: false),
                    sTmpData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iTmpLength = table.Column<int>(type: "int", nullable: false),
                    iFlag = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userBiometricData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userCardData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sdwEnrollNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iPrivilege = table.Column<int>(type: "int", nullable: false),
                    bEnabled = table.Column<bool>(type: "bit", nullable: false),
                    sCardnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCardData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userFaceData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iPrivilege = table.Column<int>(type: "int", nullable: false),
                    bEnabled = table.Column<bool>(type: "bit", nullable: false),
                    iFaceIndex = table.Column<int>(type: "int", nullable: false),
                    sTmpData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aiData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iLength = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userFaceData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    ProfilePictureDataUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "accessDevice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationType = table.Column<byte>(type: "tinyint", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCount = table.Column<int>(type: "int", nullable: false),
                    AdminCount = table.Column<int>(type: "int", nullable: false),
                    FpCount = table.Column<int>(type: "int", nullable: false),
                    RecordCount = table.Column<int>(type: "int", nullable: false),
                    PwdCount = table.Column<int>(type: "int", nullable: false),
                    OpLogCount = table.Column<int>(type: "int", nullable: false),
                    FaceCount = table.Column<int>(type: "int", nullable: false),
                    DeviceIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<byte>(type: "tinyint", nullable: false),
                    DeviceType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accessDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accessDevice_location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spectraStaffBiometricData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    StaffCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finger = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Quality = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spectraStaffBiometricData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_spectraStaffBiometricData_staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spectraBiometricData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finger = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Quality = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spectraBiometricData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_spectraBiometricData_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentCourseMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentCourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentCourseMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentCourseMap_studentCourse_StudentCourseId",
                        column: x => x.StudentCourseId,
                        principalTable: "studentCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentCourseMap_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "canteenStaffAccessDeviceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    AccessDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canteenStaffAccessDeviceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_canteenStaffAccessDeviceStatus_accessDevice_AccessDeviceId",
                        column: x => x.AccessDeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_canteenStaffAccessDeviceStatus_staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "canteenStaffAttendanceLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idwVerifyMode = table.Column<int>(type: "int", nullable: false),
                    idwInOutMode = table.Column<int>(type: "int", nullable: false),
                    idwYear = table.Column<int>(type: "int", nullable: false),
                    idwMonth = table.Column<int>(type: "int", nullable: false),
                    idwDay = table.Column<int>(type: "int", nullable: false),
                    idwHour = table.Column<int>(type: "int", nullable: false),
                    idwMinute = table.Column<int>(type: "int", nullable: false),
                    idwSecond = table.Column<int>(type: "int", nullable: false),
                    idwWorkcode = table.Column<int>(type: "int", nullable: false),
                    PunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canteenStaffAttendanceLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_canteenStaffAttendanceLog_accessDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_canteenStaffAttendanceLog_staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "canteenStudentAccessDeviceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AccessDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canteenStudentAccessDeviceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_canteenStudentAccessDeviceStatus_accessDevice_AccessDeviceId",
                        column: x => x.AccessDeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_canteenStudentAccessDeviceStatus_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "canteenStudentAttendanceLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idwVerifyMode = table.Column<int>(type: "int", nullable: false),
                    idwInOutMode = table.Column<int>(type: "int", nullable: false),
                    idwYear = table.Column<int>(type: "int", nullable: false),
                    idwMonth = table.Column<int>(type: "int", nullable: false),
                    idwDay = table.Column<int>(type: "int", nullable: false),
                    idwHour = table.Column<int>(type: "int", nullable: false),
                    idwMinute = table.Column<int>(type: "int", nullable: false),
                    idwSecond = table.Column<int>(type: "int", nullable: false),
                    idwWorkcode = table.Column<int>(type: "int", nullable: false),
                    PunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_canteenStudentAttendanceLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_canteenStudentAttendanceLog_accessDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_canteenStudentAttendanceLog_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "labStaffAccessDeviceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    AccessDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labStaffAccessDeviceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_labStaffAccessDeviceStatus_accessDevice_AccessDeviceId",
                        column: x => x.AccessDeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_labStaffAccessDeviceStatus_staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "labStaffAccessLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idwVerifyMode = table.Column<int>(type: "int", nullable: false),
                    idwInOutMode = table.Column<int>(type: "int", nullable: false),
                    idwYear = table.Column<int>(type: "int", nullable: false),
                    idwMonth = table.Column<int>(type: "int", nullable: false),
                    idwDay = table.Column<int>(type: "int", nullable: false),
                    idwHour = table.Column<int>(type: "int", nullable: false),
                    idwMinute = table.Column<int>(type: "int", nullable: false),
                    idwSecond = table.Column<int>(type: "int", nullable: false),
                    idwWorkcode = table.Column<int>(type: "int", nullable: false),
                    PunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labStaffAccessLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_labStaffAccessLog_accessDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_labStaffAccessLog_staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "labStudentAccessDeviceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AccessDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labStudentAccessDeviceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_labStudentAccessDeviceStatus_accessDevice_AccessDeviceId",
                        column: x => x.AccessDeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_labStudentAccessDeviceStatus_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "labStudentAccessLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idwVerifyMode = table.Column<int>(type: "int", nullable: false),
                    idwInOutMode = table.Column<int>(type: "int", nullable: false),
                    idwYear = table.Column<int>(type: "int", nullable: false),
                    idwMonth = table.Column<int>(type: "int", nullable: false),
                    idwDay = table.Column<int>(type: "int", nullable: false),
                    idwHour = table.Column<int>(type: "int", nullable: false),
                    idwMinute = table.Column<int>(type: "int", nullable: false),
                    idwSecond = table.Column<int>(type: "int", nullable: false),
                    idwWorkcode = table.Column<int>(type: "int", nullable: false),
                    PunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labStudentAccessLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_labStudentAccessLog_accessDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_labStudentAccessLog_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "libraryStaffAccessDeviceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    AccessDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libraryStaffAccessDeviceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_libraryStaffAccessDeviceStatus_accessDevice_AccessDeviceId",
                        column: x => x.AccessDeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_libraryStaffAccessDeviceStatus_staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "libraryStaffAccessLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idwVerifyMode = table.Column<int>(type: "int", nullable: false),
                    idwInOutMode = table.Column<int>(type: "int", nullable: false),
                    idwYear = table.Column<int>(type: "int", nullable: false),
                    idwMonth = table.Column<int>(type: "int", nullable: false),
                    idwDay = table.Column<int>(type: "int", nullable: false),
                    idwHour = table.Column<int>(type: "int", nullable: false),
                    idwMinute = table.Column<int>(type: "int", nullable: false),
                    idwSecond = table.Column<int>(type: "int", nullable: false),
                    idwWorkcode = table.Column<int>(type: "int", nullable: false),
                    PunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libraryStaffAccessLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_libraryStaffAccessLog_accessDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_libraryStaffAccessLog_staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "libraryStudentAccessDeviceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AccessDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libraryStudentAccessDeviceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_libraryStudentAccessDeviceStatus_accessDevice_AccessDeviceId",
                        column: x => x.AccessDeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_libraryStudentAccessDeviceStatus_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "libraryStudentAccessLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idwVerifyMode = table.Column<int>(type: "int", nullable: false),
                    idwInOutMode = table.Column<int>(type: "int", nullable: false),
                    idwYear = table.Column<int>(type: "int", nullable: false),
                    idwMonth = table.Column<int>(type: "int", nullable: false),
                    idwDay = table.Column<int>(type: "int", nullable: false),
                    idwHour = table.Column<int>(type: "int", nullable: false),
                    idwMinute = table.Column<int>(type: "int", nullable: false),
                    idwSecond = table.Column<int>(type: "int", nullable: false),
                    idwWorkcode = table.Column<int>(type: "int", nullable: false),
                    PunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libraryStudentAccessLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_libraryStudentAccessLog_accessDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_libraryStudentAccessLog_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spectraDeviceAccessLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RollNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sync = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spectraDeviceAccessLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_spectraDeviceAccessLog_accessDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spectraDeviceAccessLog_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffAccessDeviceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    AccessDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffAccessDeviceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_staffAccessDeviceStatus_accessDevice_AccessDeviceId",
                        column: x => x.AccessDeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_staffAccessDeviceStatus_staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffAccessLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idwVerifyMode = table.Column<int>(type: "int", nullable: false),
                    idwInOutMode = table.Column<int>(type: "int", nullable: false),
                    idwYear = table.Column<int>(type: "int", nullable: false),
                    idwMonth = table.Column<int>(type: "int", nullable: false),
                    idwDay = table.Column<int>(type: "int", nullable: false),
                    idwHour = table.Column<int>(type: "int", nullable: false),
                    idwMinute = table.Column<int>(type: "int", nullable: false),
                    idwSecond = table.Column<int>(type: "int", nullable: false),
                    idwWorkcode = table.Column<int>(type: "int", nullable: false),
                    PunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sync = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffAccessLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_staffAccessLog_accessDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_staffAccessLog_staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentAccessDeviceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AccessDeviceId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentAccessDeviceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentAccessDeviceStatus_accessDevice_AccessDeviceId",
                        column: x => x.AccessDeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentAccessDeviceStatus_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentAccessLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idwVerifyMode = table.Column<int>(type: "int", nullable: false),
                    idwInOutMode = table.Column<int>(type: "int", nullable: false),
                    idwYear = table.Column<int>(type: "int", nullable: false),
                    idwMonth = table.Column<int>(type: "int", nullable: false),
                    idwDay = table.Column<int>(type: "int", nullable: false),
                    idwHour = table.Column<int>(type: "int", nullable: false),
                    idwMinute = table.Column<int>(type: "int", nullable: false),
                    idwSecond = table.Column<int>(type: "int", nullable: false),
                    idwWorkcode = table.Column<int>(type: "int", nullable: false),
                    PunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentAccessLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentAccessLog_accessDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentAccessLog_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accessDevice_LocationId",
                table: "accessDevice",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_accessDevice_Name",
                table: "accessDevice",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_canteenStaffAccessDeviceStatus_AccessDeviceId",
                table: "canteenStaffAccessDeviceStatus",
                column: "AccessDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_canteenStaffAccessDeviceStatus_StaffId",
                table: "canteenStaffAccessDeviceStatus",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_canteenStaffAttendanceLog_DeviceId",
                table: "canteenStaffAttendanceLog",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_canteenStaffAttendanceLog_StaffId",
                table: "canteenStaffAttendanceLog",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_canteenStudentAccessDeviceStatus_AccessDeviceId",
                table: "canteenStudentAccessDeviceStatus",
                column: "AccessDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_canteenStudentAccessDeviceStatus_StudentId",
                table: "canteenStudentAccessDeviceStatus",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_canteenStudentAttendanceLog_DeviceId",
                table: "canteenStudentAttendanceLog",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_canteenStudentAttendanceLog_StudentId",
                table: "canteenStudentAttendanceLog",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_labStaffAccessDeviceStatus_AccessDeviceId",
                table: "labStaffAccessDeviceStatus",
                column: "AccessDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_labStaffAccessDeviceStatus_StaffId",
                table: "labStaffAccessDeviceStatus",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_labStaffAccessLog_DeviceId",
                table: "labStaffAccessLog",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_labStaffAccessLog_StaffId",
                table: "labStaffAccessLog",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_labStudentAccessDeviceStatus_AccessDeviceId",
                table: "labStudentAccessDeviceStatus",
                column: "AccessDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_labStudentAccessDeviceStatus_StudentId",
                table: "labStudentAccessDeviceStatus",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_labStudentAccessLog_DeviceId",
                table: "labStudentAccessLog",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_labStudentAccessLog_StudentId",
                table: "labStudentAccessLog",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_libraryStaffAccessDeviceStatus_AccessDeviceId",
                table: "libraryStaffAccessDeviceStatus",
                column: "AccessDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_libraryStaffAccessDeviceStatus_StaffId",
                table: "libraryStaffAccessDeviceStatus",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_libraryStaffAccessLog_DeviceId",
                table: "libraryStaffAccessLog",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_libraryStaffAccessLog_StaffId",
                table: "libraryStaffAccessLog",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_libraryStudentAccessDeviceStatus_AccessDeviceId",
                table: "libraryStudentAccessDeviceStatus",
                column: "AccessDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_libraryStudentAccessDeviceStatus_StudentId",
                table: "libraryStudentAccessDeviceStatus",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_libraryStudentAccessLog_DeviceId",
                table: "libraryStudentAccessLog",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_libraryStudentAccessLog_StudentId",
                table: "libraryStudentAccessLog",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_location_Name",
                table: "location",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_spectraBiometricData_StudentId",
                table: "spectraBiometricData",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_spectraDeviceAccessLog_DeviceId",
                table: "spectraDeviceAccessLog",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_spectraDeviceAccessLog_StudentId",
                table: "spectraDeviceAccessLog",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_spectraStaffBiometricData_StaffId",
                table: "spectraStaffBiometricData",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_staff_EmpId",
                table: "staff",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_staffAccessDeviceStatus_AccessDeviceId",
                table: "staffAccessDeviceStatus",
                column: "AccessDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_staffAccessDeviceStatus_StaffId",
                table: "staffAccessDeviceStatus",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_staffAccessLog_DeviceId",
                table: "staffAccessLog",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_staffAccessLog_StaffId",
                table: "staffAccessLog",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_student_RollNo",
                table: "student",
                column: "RollNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentAccessDeviceStatus_AccessDeviceId",
                table: "studentAccessDeviceStatus",
                column: "AccessDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_studentAccessDeviceStatus_StudentId",
                table: "studentAccessDeviceStatus",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_studentAccessLog_DeviceId",
                table: "studentAccessLog",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_studentAccessLog_StudentId",
                table: "studentAccessLog",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_studentCourse_CourseId",
                table: "studentCourse",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentCourseMap_StudentCourseId",
                table: "studentCourseMap",
                column: "StudentCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_studentCourseMap_StudentId",
                table: "studentCourseMap",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditTrails");

            migrationBuilder.DropTable(
                name: "canteenStaffAccessDeviceStatus");

            migrationBuilder.DropTable(
                name: "canteenStaffAttendanceLog");

            migrationBuilder.DropTable(
                name: "canteenStudentAccessDeviceStatus");

            migrationBuilder.DropTable(
                name: "canteenStudentAttendanceLog");

            migrationBuilder.DropTable(
                name: "labStaffAccessDeviceStatus");

            migrationBuilder.DropTable(
                name: "labStaffAccessLog");

            migrationBuilder.DropTable(
                name: "labStudentAccessDeviceStatus");

            migrationBuilder.DropTable(
                name: "labStudentAccessLog");

            migrationBuilder.DropTable(
                name: "libraryStaffAccessDeviceStatus");

            migrationBuilder.DropTable(
                name: "libraryStaffAccessLog");

            migrationBuilder.DropTable(
                name: "libraryStudentAccessDeviceStatus");

            migrationBuilder.DropTable(
                name: "libraryStudentAccessLog");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "serviceNotification");

            migrationBuilder.DropTable(
                name: "spectraBiometricData");

            migrationBuilder.DropTable(
                name: "spectraDeviceAccessLog");

            migrationBuilder.DropTable(
                name: "spectraStaffBiometricData");

            migrationBuilder.DropTable(
                name: "staffAccessDeviceStatus");

            migrationBuilder.DropTable(
                name: "staffAccessLog");

            migrationBuilder.DropTable(
                name: "studentAccessDeviceStatus");

            migrationBuilder.DropTable(
                name: "studentAccessLog");

            migrationBuilder.DropTable(
                name: "studentBiometricData");

            migrationBuilder.DropTable(
                name: "studentCardData");

            migrationBuilder.DropTable(
                name: "studentCourseMap");

            migrationBuilder.DropTable(
                name: "studentFaceData");

            migrationBuilder.DropTable(
                name: "ToMailSettings");

            migrationBuilder.DropTable(
                name: "userBiometricData");

            migrationBuilder.DropTable(
                name: "userCardData");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "userFaceData");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "staff");

            migrationBuilder.DropTable(
                name: "accessDevice");

            migrationBuilder.DropTable(
                name: "studentCourse");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "location");
        }
    }
}
