using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.api.Data.Migrations
{
    public partial class Second2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opções",
                table: "Eventos",
                newName: "Opcoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Opcoes",
                table: "Eventos",
                newName: "Opções");
        }
    }
}
