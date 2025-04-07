using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planify.Migrations
{
    /// <inheritdoc />
    public partial class pagosdetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Presupuestos_EventoId",
                table: "Presupuestos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_PresupuestoId",
                table: "Pagos");

            migrationBuilder.CreateTable(
                name: "PagosDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PagoId = table.Column<int>(type: "int", nullable: false),
                    NombreArticulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_PagosDetalle_Pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "PagoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_EventoId",
                table: "Presupuestos",
                column: "EventoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_PresupuestoId",
                table: "Pagos",
                column: "PresupuestoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PagosDetalle_PagoId",
                table: "PagosDetalle",
                column: "PagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagosDetalle");

            migrationBuilder.DropIndex(
                name: "IX_Presupuestos_EventoId",
                table: "Presupuestos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_PresupuestoId",
                table: "Pagos");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_EventoId",
                table: "Presupuestos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_PresupuestoId",
                table: "Pagos",
                column: "PresupuestoId");
        }
    }
}
