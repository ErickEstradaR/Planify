using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planify.Models;

public class TarjetasCredito
{
    [Key]
    public int TarjetaId { get; set; }
    
    [Required]
    public string NumTarjetaCredito { get; set; }
    
    [Required]
    public int Ccv { get; set; }
    
    public DateTime FechaExp { get; set; }
    
    public string Banco { get; set; }
    
    public string ApodoTarjetaCredito { get; set; }
    
    public int ClienteId { get; set; }
    
    [ForeignKey("ClienteId")]
    public Clientes Cliente { get; set; }
}