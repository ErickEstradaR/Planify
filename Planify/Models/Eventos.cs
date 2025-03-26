using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planify.Models;

public class Eventos
{
    
    [Key]
    public int EventoId { get; set; }
    
    public string NombreEvento { get; set; }
    public string Categoria { get; set; }
    
    public string Descripcion { get; set; }
    
    public string Direccion { get; set; }
    
    public DateTime FechaEvento { get; set; }
    
    public string UserId { get; set; }
    
    public int ClienteId { get; set; }
    
    [ForeignKey("ClienteId")]
    public Clientes? Cliente { get; set; }
}