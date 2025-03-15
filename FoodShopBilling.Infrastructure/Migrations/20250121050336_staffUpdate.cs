using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShopBilling.Infra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class staffUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeDeviceGroup",
                table: "staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeDevicePassword",
                table: "staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeRFIDNumber",
                table: "staff",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "iPrevilage",
                table: "staff",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeDeviceGroup",
                table: "staff");

            migrationBuilder.DropColumn(
                name: "EmployeeDevicePassword",
                table: "staff");

            migrationBuilder.DropColumn(
                name: "EmployeeRFIDNumber",
                table: "staff");

            migrationBuilder.DropColumn(
                name: "iPrevilage",
                table: "staff");
        }
    }
}
