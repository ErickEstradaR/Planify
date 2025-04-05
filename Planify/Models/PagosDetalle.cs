using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Planify.Models;

public class PagosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int PagoId { get; set; }
    [ForeignKey("PagoId")]
    public Pagos Pago { get; set; }

    public string NombreArticulo { get; set; }
    public string Descripcion { get; set; }
    public string Categoria { get; set; }

    public int Cantidad { get; set; }
    public double PrecioUnitario { get; set; }
    public double Subtotal => Cantidad * PrecioUnitario;
}