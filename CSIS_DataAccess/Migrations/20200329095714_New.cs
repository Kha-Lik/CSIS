using Microsoft.EntityFrameworkCore.Migrations;

namespace CSIS_DataAccess.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryTime",
                table: "CosmeticUsedSlowlyEnities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CosmeticUsedSlowlyEnities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "CosmeticUsedSlowlyEnities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Units",
                table: "CosmeticUsedSlowlyEnities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "CosmeticUsedSlowlyEnities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CosmeticUsedSlowlyEnities");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CosmeticUsedSlowlyEnities");

            migrationBuilder.DropColumn(
                name: "Units",
                table: "CosmeticUsedSlowlyEnities");
        }
    }
}
