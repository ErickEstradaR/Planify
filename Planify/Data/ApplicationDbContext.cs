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
    public DbSet<TarjetasCredito> TarjetasCredito { get; set; }
    public DbSet<Pagos> Pagos { get; set; }
    public DbSet<PagosDetalle> PagosDetalles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulos>().HasData(
            new List<Articulos>
            {
                new Articulos { ArticuloId = -1, Precio = 19.99, Nombre = "Producto 1", Descripcion = "Descripción del producto 1", Categoria = "Categoría A" },
                new Articulos { ArticuloId = -2, Precio = 29.99, Nombre = "Producto 2", Descripcion = "Descripción del producto 2", Categoria = "Categoría B"},
                new Articulos { ArticuloId = -3, Precio = 39.99, Nombre = "Producto 3", Descripcion = "Descripción del producto 3", Categoria = "Categoría C"}
            }
        );
        // In your DbContext or model configuration
        modelBuilder.Entity<PresupuestosDetalle>()
            .Property(p => p.DetalleId)
            .ValueGeneratedOnAdd();
    
        base.OnModelCreating(modelBuilder);
    }
    
    
    
}