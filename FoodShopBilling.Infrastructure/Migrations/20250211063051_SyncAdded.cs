using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShopBilling.Infra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SyncAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sync",
                table: "libraryStudentAccessLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sync",
                table: "libraryStaffAccessLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sync",
                table: "labStudentAccessLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sync",
                table: "labStaffAccessLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sync",
                table: "canteenStudentAttendanceLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sync",
                table: "canteenStaffAttendanceLog",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sync",
                table: "libraryStudentAccessLog");

            migrationBuilder.DropColumn(
                name: "Sync",
                table: "libraryStaffAccessLog");

            migrationBuilder.DropColumn(
                name: "Sync",
                table: "labStudentAccessLog");

            migrationBuilder.DropColumn(
                name: "Sync",
                table: "labStaffAccessLog");

            migrationBuilder.DropColumn(
                name: "Sync",
                table: "canteenStudentAttendanceLog");

            migrationBuilder.DropColumn(
                name: "Sync",
                table: "canteenStaffAttendanceLog");
        }
    }
}
