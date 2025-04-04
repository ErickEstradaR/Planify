using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planify.Models;

public class TarjetasCredito
{
    [Key]
    public int TarjetaId { get; set; }
    
    [Required(ErrorMessage = "El número de tarjeta es obligatorio.")]
    [CreditCard(ErrorMessage = "El número de tarjeta no es válido.")]
    [StringLength(19, MinimumLength = 13, ErrorMessage = "El número de tarjeta debe tener entre 13 y 19 dígitos.")]
    public string NumTarjetaCredito { get; set; }
    
    [Required(ErrorMessage = "El código CCV es obligatorio.")]
    [Range(100, 9999, ErrorMessage = "El CCV debe ser un número de 3 o 4 dígitos.")]
    public int Ccv { get; set; }
    
    [Required(ErrorMessage = "La fecha de expiración es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime FechaExp { get; set; }
    
    public string Banco { get; set; }
    
    [StringLength(10, ErrorMessage = "El apodo no puede superar los 10 caracteres.")]
    public string ApodoTarjetaCredito { get; set; }
    
    public int ClienteId { get; set; }
    
    [ForeignKey("ClienteId")]
    public Clientes Cliente { get; set; }
}