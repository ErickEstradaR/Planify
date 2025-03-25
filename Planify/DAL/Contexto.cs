using Microsoft.EntityFrameworkCore;
using Planify.Models;

namespace Planify.DAL;

public class Contexto : DbContext
{
 public Contexto(DbContextOptions<Contexto> options) : base(options) { }  
 
  public DbSet<Articulos> Articulos { get; set; }
  public DbSet<Eventos> Eventos { get; set; }
  public DbSet<Clientes> Clientes { get; set; }
  public DbSet<Presupuestos> Presupuestos { get; set; }
  public DbSet<PresupuestosDetalle> PresupuestosDetalles { get; set; }
  
}