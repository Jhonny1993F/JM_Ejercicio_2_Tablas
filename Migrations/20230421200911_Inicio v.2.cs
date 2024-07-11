using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JM_Ejercicio_2_Tablas.Migrations
{
    public partial class Iniciov2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "Burger",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Burger");
        }
    }
}
