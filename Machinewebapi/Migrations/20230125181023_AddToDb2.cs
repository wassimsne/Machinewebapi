using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Machinewebapi.Migrations
{
    public partial class AddToDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Machines_IdLaverie",
                table: "Machines",
                column: "IdLaverie");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Laveries_IdLaverie",
                table: "Machines",
                column: "IdLaverie",
                principalTable: "Laveries",
                principalColumn: "IdLav",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Laveries_IdLaverie",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_IdLaverie",
                table: "Machines");
        }
    }
}
