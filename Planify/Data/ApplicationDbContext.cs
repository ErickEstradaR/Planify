using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Planify.Models;

namespace Planify.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options) 
{
    public DbSet<Articulos> Articulos { get; set; }
    public DbSet<Eventos> Eventos { get; set; }
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Presupuestos> Presupuestos { get; set; }
    public DbSet<PresupuestosDetalle> PresupuestosDetalles { get; set; }
}