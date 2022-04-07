using Microsoft.EntityFrameworkCore.Migrations;

namespace DoorsAppProj.Migrations
{
    public partial class Dooring5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsClosed = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    GivenName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doors");
        }
    }
}
