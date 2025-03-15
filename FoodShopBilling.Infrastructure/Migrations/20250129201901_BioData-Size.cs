using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShopBilling.Infra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BioDataSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "biometricData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "biometricData");
        }
    }
}
