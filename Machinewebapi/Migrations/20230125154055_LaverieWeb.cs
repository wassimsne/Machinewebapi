using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Machinewebapi.Migrations
{
    public partial class LaverieWeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    IdMachine = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLaverie = table.Column<int>(type: "int", nullable: false),
                    etat = table.Column<int>(type: "int", nullable: false),
                    DureeToalDeFonctionnement = table.Column<int>(type: "int", nullable: false),
                    NumeroCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.IdMachine);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
