using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShopBilling.Infra.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class facefingercolum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFaceRegistered",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFingerRegistered",
                table: "student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFaceRegistered",
                table: "staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFingerRegistered",
                table: "staff",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFaceRegistered",
                table: "student");

            migrationBuilder.DropColumn(
                name: "IsFingerRegistered",
                table: "student");

            migrationBuilder.DropColumn(
                name: "IsFaceRegistered",
                table: "staff");

            migrationBuilder.DropColumn(
                name: "IsFingerRegistered",
                table: "staff");
        }
    }
}
