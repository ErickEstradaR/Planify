using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planify.Migrations
{
    /// <inheritdoc />
    public partial class tarjettapago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_TarjetasCredito_TarjetaId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_TarjetaId",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "TarjetaId",
                table: "Pagos");

            migrationBuilder.AddColumn<string>(
                name: "ApodoTarjeta",
                table: "Pagos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Banco",
                table: "Pagos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitularTarjeta",
                table: "Pagos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ultimos4Digitos",
                table: "Pagos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApodoTarjeta",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "Banco",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "TitularTarjeta",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "Ultimos4Digitos",
                table: "Pagos");

            migrationBuilder.AddColumn<int>(
                name: "TarjetaId",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TarjetaId",
                table: "Pagos",
                column: "TarjetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_TarjetasCredito_TarjetaId",
                table: "Pagos",
                column: "TarjetaId",
                principalTable: "TarjetasCredito",
                principalColumn: "TarjetaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
