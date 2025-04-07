using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planify.Models;

public class TarjetasCredito
{
    [Key]
    public int TarjetaId { get; set; }
    
    [Required(ErrorMessage = "El número de tarjeta es obligatorio.")]
    [StringLength(19, MinimumLength = 13, ErrorMessage = "El número de tarjeta debe tener entre 13 y 19 dígitos.")]
    [RegularExpression("^[0-9]+$", ErrorMessage = "El número de tarjeta solo puede contener dígitos.")]
    public string NumTarjetaCredito { get; set; }
    
    [Required(ErrorMessage = "El código CCV es obligatorio.")]
    [Range(100, 9999, ErrorMessage = "El CCV debe ser un número de 3 o 4 dígitos.")]
    public int Ccv { get; set; }
    
    [Required(ErrorMessage = "La fecha de expiración es obligatoria.")]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Formato inválido. Use MM/YY.")]
    public string FechaExp { get; set; }
    
    [Required(ErrorMessage = "El nombre del titular es obligatorio.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "El nombre debe tener entre 5 y 100 caracteres.")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
    public string TitularTarjeta { get; set; }
    
    public string Banco { get; set; }
    
    [StringLength(10, ErrorMessage = "El apodo no puede superar los 10 caracteres.")]
    public string ApodoTarjetaCredito { get; set; }
    
    public int ClienteId { get; set; }
    
    [ForeignKey("ClienteId")]
    public Clientes Cliente { get; set; }
}