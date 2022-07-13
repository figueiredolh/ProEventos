using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.api.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Eventos",
                newName: "Tema");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Eventos",
                newName: "Data");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Eventos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "Eventos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lote",
                table: "Eventos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Opções",
                table: "Eventos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QtdPessoas",
                table: "Eventos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Local",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Lote",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Opções",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "QtdPessoas",
                table: "Eventos");

            migrationBuilder.RenameColumn(
                name: "Tema",
                table: "Eventos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Eventos",
                newName: "Date");
        }
    }
}
