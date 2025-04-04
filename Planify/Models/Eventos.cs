using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planify.Models;

public class Eventos
{
    
    [Key]
    public int EventoId { get; set; }
    
    [Required(ErrorMessage = "El nombre del evento es obligatorio.")]
    [MinLength(5, ErrorMessage = "El nombre debe tener al menos 5 caracteres.")]
    [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string NombreEvento { get; set; }

    [Required(ErrorMessage = "La categoría es obligatoria.")]
    public string Categoria { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [MinLength(5, ErrorMessage = "La descripción debe tener al menos 5 caracteres.")]
    [MaxLength(50, ErrorMessage = "La descripción no puede superar los 50 caracteres.")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "La dirección es obligatoria.")]
    [MinLength(10, ErrorMessage = "La dirección debe tener al menos 10 caracteres.")]
    [MaxLength(100, ErrorMessage = "La dirección no puede superar los 100 caracteres.")]
    public string Direccion { get; set; }

    [Required(ErrorMessage = "La fecha del evento es obligatoria.")]
    public DateTime FechaEvento { get; set; } = DateTime.Now.AddDays(7); 
    [Required]
    public string UserId { get; set; }
    
    public int ClienteId { get; set; }
    
    [ForeignKey("ClienteId")]
    public Clientes? Cliente { get; set; }
}