using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consumos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tramo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResidencialWh = table.Column<int>(type: "int", nullable: false),
                    ComercialWh = table.Column<int>(type: "int", nullable: false),
                    IndustrialWh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Costos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tramo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResidencialCosto = table.Column<decimal>(type: "decimal(12,10)", nullable: false),
                    ComercialCosto = table.Column<decimal>(type: "decimal(12,10)", nullable: false),
                    IndustrialCosto = table.Column<decimal>(type: "decimal(12,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perdidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tramo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResidencialPorcentaje = table.Column<decimal>(type: "decimal(12,10)", nullable: false),
                    ComercialPorcentaje = table.Column<decimal>(type: "decimal(12,10)", nullable: false),
                    IndustrialPorcentaje = table.Column<decimal>(type: "decimal(12,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perdidas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumos");

            migrationBuilder.DropTable(
                name: "Costos");

            migrationBuilder.DropTable(
                name: "Perdidas");
        }
    }
}
