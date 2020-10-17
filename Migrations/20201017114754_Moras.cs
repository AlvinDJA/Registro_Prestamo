using Microsoft.EntityFrameworkCore.Migrations;

namespace Registro_Prestamo.Migrations
{
    public partial class Moras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "MorasDetalle");

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "MorasDetalle",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "MorasDetalle");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "MorasDetalle",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
