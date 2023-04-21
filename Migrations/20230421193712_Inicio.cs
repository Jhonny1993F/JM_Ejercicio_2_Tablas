using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JM_Ejercicio_2_Tablas.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burger",
                columns: table => new
                {
                    BurgerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WithCheese = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burger", x => x.BurgerID);
                });

            migrationBuilder.CreateTable(
                name: "Promo",
                columns: table => new
                {
                    PromoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BurgerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promo", x => x.PromoId);
                    table.ForeignKey(
                        name: "FK_Promo_Burger_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burger",
                        principalColumn: "BurgerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promo_BurgerId",
                table: "Promo",
                column: "BurgerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promo");

            migrationBuilder.DropTable(
                name: "Burger");
        }
    }
}
