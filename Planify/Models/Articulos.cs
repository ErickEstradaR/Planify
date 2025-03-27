using System.ComponentModel.DataAnnotations;

namespace Planify.Models;

public class Articulos
{
    [Key]
    public int ArticuloId { get; set; }
    
    public double Precio { get; set; }
    
    public string Nombre { get; set; }
    
    public string Descripcion { get; set; }
    
    public string Categoria { get; set; }
    
}