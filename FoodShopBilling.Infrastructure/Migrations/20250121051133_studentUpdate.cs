using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShopBilling.Infra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class studentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeDeviceGroup",
                table: "student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeDevicePassword",
                table: "student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeRFIDNumber",
                table: "student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "iPrevilage",
                table: "student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeDeviceGroup",
                table: "student");

            migrationBuilder.DropColumn(
                name: "EmployeeDevicePassword",
                table: "student");

            migrationBuilder.DropColumn(
                name: "EmployeeRFIDNumber",
                table: "student");

            migrationBuilder.DropColumn(
                name: "iPrevilage",
                table: "student");
        }
    }
}
