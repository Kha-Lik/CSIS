using Microsoft.EntityFrameworkCore.Migrations;

namespace CSIS_DataAccess.Migrations
{
    public partial class RemoveEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CosmeticUsedSlowlyEnities");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnding",
                table: "CosmeticEntities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ShelfLife",
                table: "CosmeticEntities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsingTime",
                table: "CosmeticEntities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "CosmeticEntities",
                columns: new[] { "Id", "DeliveryTime", "IsEnding", "Name", "Price", "ShelfLife", "Units", "UsingTime" },
                values: new object[] { 1, 13, false, "1st", 567, 180, 987, 100 });

            migrationBuilder.InsertData(
                table: "CosmeticEntities",
                columns: new[] { "Id", "DeliveryTime", "IsEnding", "Name", "Price", "ShelfLife", "Units", "UsingTime" },
                values: new object[] { 2, 3, true, "2nd", 134, 360, 20, 300 });

            migrationBuilder.InsertData(
                table: "CosmeticEntities",
                columns: new[] { "Id", "DeliveryTime", "IsEnding", "Name", "Price", "ShelfLife", "Units", "UsingTime" },
                values: new object[] { 3, 18, false, "3rd", 111, 90, 70, 80 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CosmeticEntities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CosmeticEntities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CosmeticEntities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "IsEnding",
                table: "CosmeticEntities");

            migrationBuilder.DropColumn(
                name: "ShelfLife",
                table: "CosmeticEntities");

            migrationBuilder.DropColumn(
                name: "UsingTime",
                table: "CosmeticEntities");

            migrationBuilder.CreateTable(
                name: "CosmeticUsedSlowlyEnities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryTime = table.Column<int>(type: "int", nullable: false),
                    IsEnding = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ShelfLife = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    UsingTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosmeticUsedSlowlyEnities", x => x.Id);
                });
        }
    }
}
