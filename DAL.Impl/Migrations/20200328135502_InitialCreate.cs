using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Impl.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "CosmeticEntities",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(),
                    Units = table.Column<int>(),
                    DeliveryTime = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_CosmeticEntities", x => x.Id); });

            migrationBuilder.CreateTable(
                "CosmeticUsedSlowlyEnities",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelfLife = table.Column<int>(),
                    UsingTime = table.Column<int>(),
                    IsEnding = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("PK_CosmeticUsedSlowlyEnities", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CosmeticEntities");

            migrationBuilder.DropTable(
                "CosmeticUsedSlowlyEnities");
        }
    }
}