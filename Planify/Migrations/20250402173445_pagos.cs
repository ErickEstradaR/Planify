using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planify.Migrations
{
    /// <inheritdoc />
    public partial class pagos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    FechaCobro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DireccionEnvio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresupuestoId = table.Column<int>(type: "int", nullable: false),
                    TarjetaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pagos_Presupuestos_PresupuestoId",
                        column: x => x.PresupuestoId,
                        principalTable: "Presupuestos",
                        principalColumn: "PresupuestoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_TarjetasCredito_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "TarjetasCredito",
                        principalColumn: "TarjetaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_PresupuestoId",
                table: "Pagos",
                column: "PresupuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TarjetaId",
                table: "Pagos",
                column: "TarjetaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");
        }
    }
}
