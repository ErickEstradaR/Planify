using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planify.Models;

public class Presupuestos
{
    [Key]
    public int PresupuestoId { get; set; }
    
    public string UserId { get; set; }
    
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage ="Por favor seleccione un evento")]
    public int EventoId { get; set; }
    [ForeignKey("EventoId")] 
    public Eventos Evento { get; set; } = null!;
    
    [Required]
    [Range(1, int.MaxValue)]
    public double MontoTotal { get; set; }
    
    public List<PresupuestosDetalle> PresupuestosDetalles { get; set; } = new List<PresupuestosDetalle>();

    public Pagos? Pago { get; set; }

}