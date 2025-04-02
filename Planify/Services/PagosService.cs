using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Planify.Data;
using Planify.Models;

namespace Planify.Services;

public class PagosService (IDbContextFactory<ApplicationDbContext> dbfactory)
{
     /// <summary>
    /// Este método inserta  un pago en la base de datos 
    /// </summary>
    /// <param name="pago"></param>
    /// <returns>retorna un bool si la operacion es exitosa y false si falla</returns>
    public async Task<bool> Guardar(Pagos pago)
    {
            return await Insertar(pago);
    }
     
    /// <summary>
    /// Permite insertar un nuevo pago en la base de datos
    /// </summary>
    /// <param name="pago"></param>
    /// <returns>Verdadero si es insertado exitosamente y falso si no</returns>
    private async Task<bool> Insertar(Pagos pago)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        contexto.Pagos.Add(pago);
        return await contexto.SaveChangesAsync() > 0;
    }
    
    /// <summary>
    /// Lista los pagos según el criterio que reciba
    /// </summary>
    /// <param name="Pago"></param>
    /// <returns>Una lista de Pagos que cumplan con el criterio</returns>
    public async Task<List<Pagos>> Listar(Expression<Func<Pagos, bool>> Criterio)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Pagos.AsNoTracking().Where(Criterio).ToListAsync();
    }
    
    /// <summary>
    /// permite buscar un pago segun su Id
    /// </summary>
    /// <param name="PagoId"></param>
    /// <returns>Retorna un objeto Pago</returns>
    public async Task<Pagos?> Buscar(int PagoId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Pagos.FirstOrDefaultAsync(p => p.PagoId == PagoId);
    }
}