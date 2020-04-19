using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RemoveEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CosmeticUsedSlowlyEnities");

            migrationBuilder.AddColumn<bool>(
                "IsEnding",
                "CosmeticEntities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                "ShelfLife",
                "CosmeticEntities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "UsingTime",
                "CosmeticEntities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                "CosmeticEntities",
                new[] {"Id", "DeliveryTime", "IsEnding", "Name", "Price", "ShelfLife", "Units", "UsingTime"},
                new object[] {1, 13, false, "1st", 567, 180, 987, 100});

            migrationBuilder.InsertData(
                "CosmeticEntities",
                new[] {"Id", "DeliveryTime", "IsEnding", "Name", "Price", "ShelfLife", "Units", "UsingTime"},
                new object[] {2, 3, true, "2nd", 134, 360, 20, 300});

            migrationBuilder.InsertData(
                "CosmeticEntities",
                new[] {"Id", "DeliveryTime", "IsEnding", "Name", "Price", "ShelfLife", "Units", "UsingTime"},
                new object[] {3, 18, false, "3rd", 111, 90, 70, 80});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "CosmeticEntities",
                "Id",
                1);

            migrationBuilder.DeleteData(
                "CosmeticEntities",
                "Id",
                2);

            migrationBuilder.DeleteData(
                "CosmeticEntities",
                "Id",
                3);

            migrationBuilder.DropColumn(
                "IsEnding",
                "CosmeticEntities");

            migrationBuilder.DropColumn(
                "ShelfLife",
                "CosmeticEntities");

            migrationBuilder.DropColumn(
                "UsingTime",
                "CosmeticEntities");

            migrationBuilder.CreateTable(
                "CosmeticUsedSlowlyEnities",
                table => new
                {
                    Id = table.Column<int>("int")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryTime = table.Column<int>("int"),
                    IsEnding = table.Column<bool>("bit"),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Price = table.Column<int>("int"),
                    ShelfLife = table.Column<int>("int"),
                    Units = table.Column<int>("int"),
                    UsingTime = table.Column<int>("int")
                },
                constraints: table => { table.PrimaryKey("PK_CosmeticUsedSlowlyEnities", x => x.Id); });
        }
    }
}