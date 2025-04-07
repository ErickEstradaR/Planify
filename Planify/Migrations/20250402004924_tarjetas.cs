using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planify.Migrations
{
    /// <inheritdoc />
    public partial class tarjetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Clientes");

            migrationBuilder.CreateTable(
                name: "TarjetasCredito",
                columns: table => new
                {
                    TarjetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumTarjetaCredito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ccv = table.Column<int>(type: "int", nullable: false),
                    NombreTarjetaCredito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Banco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApodoTarjetaCredito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetasCredito", x => x.TarjetaId);
                    table.ForeignKey(
                        name: "FK_TarjetasCredito_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TarjetasCredito_ClienteId",
                table: "TarjetasCredito",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarjetasCredito");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
