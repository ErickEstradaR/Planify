using System.ComponentModel.DataAnnotations;

namespace Planify.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }
    
    public string Nombre { get; set; }
    
    public string NumCedula { get; set; }
    
    public string NumTelefono { get; set; }
    
    public string Direccion { get; set; }
    
    public string Correo { get; set; }
    
    public DateTime FechaIngreso { get; set; }
    
}