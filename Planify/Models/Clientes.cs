using System.ComponentModel.DataAnnotations;

namespace Planify.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }
    
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
    [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El número de cédula es obligatorio.")]
    [RegularExpression(@"^\d{3}-\d{7}-\d{1}$", ErrorMessage = "El formato de la cédula debe ser XXX-XXXXXXX-X.")]
    public string NumCedula { get; set; }

    [Required(ErrorMessage = "El número de teléfono es obligatorio.")]
    [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "El formato del teléfono debe ser XXX-XXX-XXXX.")]
    public string NumTelefono { get; set; }
    [Required]
    public string Direccion { get; set; }
  
    [Required]
    public DateTime FechaIngreso { get; set; }
    [Required]
    public string UserId { get; set; }
}