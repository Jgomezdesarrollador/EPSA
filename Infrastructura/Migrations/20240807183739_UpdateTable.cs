using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ResidencialPorcentaje",
                table: "Perdidas",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)");

            migrationBuilder.AlterColumn<double>(
                name: "IndustrialPorcentaje",
                table: "Perdidas",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)");

            migrationBuilder.AlterColumn<double>(
                name: "ComercialPorcentaje",
                table: "Perdidas",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)");

            migrationBuilder.AlterColumn<double>(
                name: "ResidencialCosto",
                table: "Costos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)");

            migrationBuilder.AlterColumn<double>(
                name: "IndustrialCosto",
                table: "Costos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)");

            migrationBuilder.AlterColumn<double>(
                name: "ComercialCosto",
                table: "Costos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ResidencialPorcentaje",
                table: "Perdidas",
                type: "decimal(12,10)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "IndustrialPorcentaje",
                table: "Perdidas",
                type: "decimal(12,10)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "ComercialPorcentaje",
                table: "Perdidas",
                type: "decimal(12,10)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "ResidencialCosto",
                table: "Costos",
                type: "decimal(12,10)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "IndustrialCosto",
                table: "Costos",
                type: "decimal(12,10)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "ComercialCosto",
                table: "Costos",
                type: "decimal(12,10)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
