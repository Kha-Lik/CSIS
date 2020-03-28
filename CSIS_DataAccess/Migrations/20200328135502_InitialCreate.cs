using Microsoft.EntityFrameworkCore.Migrations;

namespace CSIS_DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CosmeticEntities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    DeliveryTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosmeticEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CosmeticUsedSlowlyEnities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelfLife = table.Column<int>(nullable: false),
                    UsingTime = table.Column<int>(nullable: false),
                    IsEnding = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosmeticUsedSlowlyEnities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CosmeticEntities");

            migrationBuilder.DropTable(
                name: "CosmeticUsedSlowlyEnities");
        }
    }
}
