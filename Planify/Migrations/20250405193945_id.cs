using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planify.Migrations
{
    /// <inheritdoc />
    public partial class id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Presupuestos_PresupuestoId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_PresupuestoId",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "PresupuestoId",
                table: "Pagos");

            migrationBuilder.AddColumn<int>(
                name: "PagoId",
                table: "Presupuestos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_PagoId",
                table: "Presupuestos",
                column: "PagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_Pagos_PagoId",
                table: "Presupuestos",
                column: "PagoId",
                principalTable: "Pagos",
                principalColumn: "PagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_Pagos_PagoId",
                table: "Presupuestos");

            migrationBuilder.DropIndex(
                name: "IX_Presupuestos_PagoId",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "PagoId",
                table: "Presupuestos");

            migrationBuilder.AddColumn<int>(
                name: "PresupuestoId",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_PresupuestoId",
                table: "Pagos",
                column: "PresupuestoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Presupuestos_PresupuestoId",
                table: "Pagos",
                column: "PresupuestoId",
                principalTable: "Presupuestos",
                principalColumn: "PresupuestoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
