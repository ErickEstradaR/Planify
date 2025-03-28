using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planify.Models;

public class Presupuestos
{
    [Key]
    public int PresupuestoId { get; set; }
    
    public string UserId { get; set; }
    
    public DateTime Fecha { get; set; } = DateTime.Now;

    public int EventoId { get; set; }
    [ForeignKey("EventoId")] 
    public Eventos Evento { get; set; } = null!;
    
    [Required]
    [Range(1, int.MaxValue)]
    public float MontoTotal { get; set; }
    
    public List<PresupuestosDetalle> PresupuestosDetalles { get; set; } = new List<PresupuestosDetalle>();
}