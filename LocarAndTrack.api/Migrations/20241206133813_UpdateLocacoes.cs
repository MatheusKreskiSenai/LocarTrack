using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocarAndTrack.api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLocacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PrecoDiaria",
                table: "Veiculos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "QtdDias",
                table: "Locacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoDiaria",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "QtdDias",
                table: "Locacoes");
        }
    }
}
