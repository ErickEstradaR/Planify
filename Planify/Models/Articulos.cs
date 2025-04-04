using System.ComponentModel.DataAnnotations;

namespace Planify.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }
    
    [Required(ErrorMessage = "Debe ingresar un valor en Precio.")]
     [Range(1, int.MaxValue,ErrorMessage = "El precio debe ser mayor a 1") ] 
    public double Precio { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
    [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [MinLength(4, ErrorMessage = " La descripción debe tener al menos 6 caracteres.")]
    [MaxLength(100, ErrorMessage = "La descripción no puede superar los 100 caracteres.")]
    public string Descripcion { get; set; }
    
    [Required(ErrorMessage = "Debe seleccionar una categoría")]
    public string Categoria { get; set; }
    
}