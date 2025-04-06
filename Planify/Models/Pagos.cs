using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Planify.Models;

public class Pagos
{
    [Key]
    public int PagoId { get; set; } 
    public double Monto { get; set; } 
    
    public double agregadoItbis { get; set; }
    
    public double MontoTotal { get; set; }
    public DateTime FechaCobro { get; set; } 
    [Required(ErrorMessage = "La dirección no puede estar vacía")]
    public string DireccionEnvio { get; set; }
    public string userId { get; set; }
    
    public string Ultimos4Digitos { get; set; }
    public string Banco { get; set; }
    public string ApodoTarjeta { get; set; }
    public string TitularTarjeta { get; set; }
    
    
    public List<PagosDetalle> Detalles { get; set; } = new List<PagosDetalle>();  

}