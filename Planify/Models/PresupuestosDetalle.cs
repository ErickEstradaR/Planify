using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planify.Models;

public class PresupuestosDetalle
{
    [Key]
    public int DetalleId { get; set; }
    
    
    public int PresupuestoId { get; set; }
    [ForeignKey("PresupuestoId")]
    public Presupuestos Presupuesto { get; set; }
    
    public int ArticuloId { get; set; }
    [ForeignKey("ArticuloId")]
    public Articulos Articulo { get; set; }
    
    public int Cantidad { get; set; }
}