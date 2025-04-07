using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planify.Migrations
{
    /// <inheritdoc />
    public partial class detalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosDetalle_Pagos_PagoId",
                table: "PagosDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagosDetalle",
                table: "PagosDetalle");

            migrationBuilder.RenameTable(
                name: "PagosDetalle",
                newName: "PagosDetalles");

            migrationBuilder.RenameIndex(
                name: "IX_PagosDetalle_PagoId",
                table: "PagosDetalles",
                newName: "IX_PagosDetalles_PagoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagosDetalles",
                table: "PagosDetalles",
                column: "DetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosDetalles_Pagos_PagoId",
                table: "PagosDetalles",
                column: "PagoId",
                principalTable: "Pagos",
                principalColumn: "PagoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagosDetalles_Pagos_PagoId",
                table: "PagosDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PagosDetalles",
                table: "PagosDetalles");

            migrationBuilder.RenameTable(
                name: "PagosDetalles",
                newName: "PagosDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_PagosDetalles_PagoId",
                table: "PagosDetalle",
                newName: "IX_PagosDetalle_PagoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagosDetalle",
                table: "PagosDetalle",
                column: "DetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosDetalle_Pagos_PagoId",
                table: "PagosDetalle",
                column: "PagoId",
                principalTable: "Pagos",
                principalColumn: "PagoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
