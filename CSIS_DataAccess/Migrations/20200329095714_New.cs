using Microsoft.EntityFrameworkCore.Migrations;

namespace CSIS_DataAccess.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "DeliveryTime",
                "CosmeticUsedSlowlyEnities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                "Name",
                "CosmeticUsedSlowlyEnities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "Price",
                "CosmeticUsedSlowlyEnities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "Units",
                "CosmeticUsedSlowlyEnities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "DeliveryTime",
                "CosmeticUsedSlowlyEnities");

            migrationBuilder.DropColumn(
                "Name",
                "CosmeticUsedSlowlyEnities");

            migrationBuilder.DropColumn(
                "Price",
                "CosmeticUsedSlowlyEnities");

            migrationBuilder.DropColumn(
                "Units",
                "CosmeticUsedSlowlyEnities");
        }
    }
}