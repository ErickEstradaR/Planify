using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Planify.Data;
using Planify.Models;

namespace Planify.Services;

public class TarjetasService (IDbContextFactory<ApplicationDbContext> dbfactory)
{
     /// <summary>
    /// Este método inserta o modifica un articulo en la base de datos dependiendo de si este existe o no
    /// </summary>
    /// <param name="articulo"></param>
    /// <returns>retorna un bool si la operacion es exitosa y false si falla</returns>
    public async Task<bool> Guardar(TarjetasCredito tarjeta)
    {
            return await Insertar(tarjeta);
    }
     
    
    /// <summary>
    /// Permite insertar un nuevo Tarjeta en la base de datos
    /// </summary>
    /// <param name="tarjeta"></param>
    /// <returns>Verdadero si es insertado exitosamente y falso si no</returns>
    private async Task<bool> Insertar(TarjetasCredito tarjeta)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        contexto.TarjetasCredito.Add(tarjeta);
        return await contexto.SaveChangesAsync() > 0;
    }


    /// <summary>
    /// Permite eliminar un tarjeta en la base de datos, utilizando su Id lo busca y si es encontrado lo elimina
    /// </summary>
    /// <param name="TarjetaId"></param>
    /// <returns>Verdadero si fue eliminado y falso si no.</returns>
    public async Task<bool> Eliminar(int TarjetaId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.
            TarjetasCredito.
            AsNoTracking().
            Where(a => a.TarjetaId == TarjetaId).
            ExecuteDeleteAsync() > 0;
    }
    
    /// <summary>
    /// Lista los TarjetasCredito según el criterio que reciba
    /// </summary>
    /// <param name="Criterio"></param>
    /// <returns>Una lista de TarjetasCredito que cumplan con el criterio</returns>
    public async Task<List<TarjetasCredito>> Listar(Expression<Func<TarjetasCredito, bool>> Criterio)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.TarjetasCredito.AsNoTracking().Where(Criterio).ToListAsync();
    }
    
    /// <summary>
    /// permite buscar un Tarjeta segun su Id
    /// </summary>
    /// <param name="TarjetaId"></param>
    /// <returns>Retorna un objeto Tarjeta</returns>
    public async Task<TarjetasCredito?> Buscar(int TarjetaId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.TarjetasCredito.FirstOrDefaultAsync(a => a.TarjetaId == TarjetaId);
    }
    
    public async Task<string?> ObtenerTipoTarjeta(string numeroTarjeta)
    {
        if (string.IsNullOrEmpty(numeroTarjeta) || numeroTarjeta.Length < 13 || numeroTarjeta.Length > 19)
        {
            return "Desconocido";
        }
        
        if (numeroTarjeta.StartsWith("4"))
        {
            return "Visa";
        }
        
        if (numeroTarjeta.StartsWith("5") || numeroTarjeta.StartsWith("2"))
        {
            return "Mastercard";
        }
        return "Desconocido";
    }
    
}