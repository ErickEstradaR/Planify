using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planify.Models;

public class Eventos
{
    
    [Key]
    public int EventoId { get; set; }
    
    [Required(ErrorMessage = "El nombre del evento es obligatorio.")]
    public string NombreEvento { get; set; }

    [Required(ErrorMessage = "La categoría es obligatoria.")]
    public string Categoria { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "La dirección es obligatoria.")]
    public string Direccion { get; set; }

    [Required(ErrorMessage = "La fecha del evento es obligatoria.")]
    public DateTime FechaEvento { get; set; }

    [Required(ErrorMessage = "El UserId es obligatorio.")]
    public string UserId { get; set; }
    
    public int ClienteId { get; set; }
    
    [ForeignKey("ClienteId")]
    public Clientes? Cliente { get; set; }
}