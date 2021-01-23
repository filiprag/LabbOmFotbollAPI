using Microsoft.EntityFrameworkCore.Migrations;

namespace LabbOmFotbollAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arenas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    arenaNamn = table.Column<string>(type: "TEXT", nullable: true),
                    Stad = table.Column<string>(type: "TEXT", nullable: true),
                    landsKod = table.Column<string>(type: "TEXT", nullable: true),
                    Kapacitet = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arenas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arenas");
        }
    }
}
