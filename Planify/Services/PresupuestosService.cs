using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Planify.DAL;
using Planify.Models;

namespace Planify.Services;

public class PresupuestosService (IDbContextFactory<Contexto> dbfactory)
{
    /// <summary>
    /// Inserta o modifica un presupuesto en la base de datos dependiendo de si este existe o no.
    /// </summary>
    /// <param name="presupuesto">Objeto Presupuestos a guardar.</param>
    /// <returns>Retorna true si la operación es exitosa, de lo contrario false.</returns>
    public async Task<bool> Guardar(Presupuestos presupuesto)
    {
        if (!await Existe(presupuesto.PresupuestoId))
        {
            return await Insertar(presupuesto);
        }
        return await Modificar(presupuesto);
    }

    /// <summary>
    /// Verifica si un presupuesto existe en la base de datos por su Id.
    /// </summary>
    /// <param name="presupuestoId">Id del presupuesto a verificar.</param>
    /// <returns>True si existe, false si no.</returns>
    public async Task<bool> Existe(int presupuestoId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Presupuestos.AnyAsync(p => p.PresupuestoId == presupuestoId);
    }

    /// <summary>
    /// Inserta un nuevo presupuesto en la base de datos.
    /// </summary>
    /// <param name="presupuesto">Objeto Presupuestos a insertar.</param>
    /// <returns>True si se inserta correctamente, false si no.</returns>
    private async Task<bool> Insertar(Presupuestos presupuesto)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        contexto.Presupuestos.Add(presupuesto);
        return await contexto.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Modifica un presupuesto existente en la base de datos.
    /// </summary>
    /// <param name="presupuesto">Objeto Presupuestos con los cambios.</param>
    /// <returns>True si se modifica correctamente, false si no.</returns>
    private async Task<bool> Modificar(Presupuestos presupuesto)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        contexto.Presupuestos.Update(presupuesto);
        return await contexto.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Elimina un presupuesto de la base de datos por su Id.
    /// </summary>
    /// <param name="presupuestoId">Id del presupuesto a eliminar.</param>
    /// <returns>True si se elimina correctamente, false si no.</returns>
    public async Task<bool> Eliminar(int presupuestoId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Presupuestos
            .AsNoTracking()
            .Where(p => p.PresupuestoId == presupuestoId)
            .ExecuteDeleteAsync() > 0;
    }

    /// <summary>
    /// Lista los presupuestos que cumplen con un criterio dado.
    /// </summary>
    /// <param name="criterio">Expresión lambda que define el criterio de búsqueda.</param>
    /// <returns>Lista de presupuestos que cumplen con el criterio.</returns>
    public async Task<List<Presupuestos>> Listar(Expression<Func<Presupuestos, bool>> criterio)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Presupuestos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    /// <summary>
    /// Busca un presupuesto por su Id.
    /// </summary>
    /// <param name="presupuestoId">Id del presupuesto a buscar.</param>
    /// <returns>Objeto Presupuestos si se encuentra, null si no.</returns>
    public async Task<Presupuestos?> Buscar(int presupuestoId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Presupuestos.FirstOrDefaultAsync(p => p.PresupuestoId == presupuestoId);
    }
}