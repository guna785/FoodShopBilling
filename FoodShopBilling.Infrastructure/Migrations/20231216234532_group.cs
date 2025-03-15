using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShopBilling.Infra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class group : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deviceUserGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_deviceUserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "deviceStaffUserGroupMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceUserGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deviceStaffUserGroupMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deviceStaffUserGroupMap_deviceUserGroup_DeviceUserGroupId",
                        column: x => x.DeviceUserGroupId,
                        principalTable: "deviceUserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deviceStaffUserGroupMap_staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deviceStudentUserGroupMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceUserGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deviceStudentUserGroupMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deviceStudentUserGroupMap_deviceUserGroup_DeviceUserGroupId",
                        column: x => x.DeviceUserGroupId,
                        principalTable: "deviceUserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deviceStudentUserGroupMap_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupDeviceAccessMap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupDeviceAccessMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_groupDeviceAccessMap_accessDevice_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "accessDevice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_groupDeviceAccessMap_deviceUserGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "deviceUserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_deviceStaffUserGroupMap_DeviceUserGroupId",
                table: "deviceStaffUserGroupMap",
                column: "DeviceUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_deviceStaffUserGroupMap_StaffId",
                table: "deviceStaffUserGroupMap",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_deviceStudentUserGroupMap_DeviceUserGroupId",
                table: "deviceStudentUserGroupMap",
                column: "DeviceUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_deviceStudentUserGroupMap_StudentId",
                table: "deviceStudentUserGroupMap",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_groupDeviceAccessMap_DeviceId",
                table: "groupDeviceAccessMap",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_groupDeviceAccessMap_GroupId",
                table: "groupDeviceAccessMap",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deviceStaffUserGroupMap");

            migrationBuilder.DropTable(
                name: "deviceStudentUserGroupMap");

            migrationBuilder.DropTable(
                name: "groupDeviceAccessMap");

            migrationBuilder.DropTable(
                name: "deviceUserGroup");
        }
    }
}
