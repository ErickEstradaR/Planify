using System.ComponentModel.DataAnnotations;

namespace Planify.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }
    
    [Required,Range(1, int.MaxValue)]
    public double Precio { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
    [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [MinLength(6, ErrorMessage = "Debe tener al menos 6 caracteres.")]
    [MaxLength(100, ErrorMessage = "No puede superar los 100 caracteres.")]
    public string Descripcion { get; set; }
    
    public string Categoria { get; set; }
    
}