using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Planify.Models;

public class Pagos
{
    [Key]
    public int PagoId { get; set; } 
    public double Monto { get; set; } 
    public DateTime FechaCobro { get; set; } 
    public string DireccionEnvio { get; set; }
    public string userId { get; set; }
    
    public int PresupuestoId { get; set; }
    [ForeignKey("PresupuestoId")]
    public Presupuestos Presupuesto { get; set; }

    
    public int TarjetaId { get; set; }
    [ForeignKey("TarjetaId")]
    public TarjetasCredito Tarjeta { get; set; }
}