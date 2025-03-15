using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShopBilling.Infra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeCardNo",
                table: "student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCardNo",
                table: "staff",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeCardNo",
                table: "student");

            migrationBuilder.DropColumn(
                name: "EmployeeCardNo",
                table: "staff");
        }
    }
}
