using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Planify.Data;
using Planify.Models;

namespace Planify.Services;

public class ArticulosService (IDbContextFactory<ApplicationDbContext> dbfactory)
{
    /// <summary>
    /// Este método inserta o modifica un articulo en la base de datos dependiendo de si este existe o no
    /// </summary>
    /// <param name="articulo"></param>
    /// <returns>retorna un bool si la operacion es exitosa y false si falla</returns>
    public async Task<bool> Guardar(Articulos articulo)
    {
        if (!await Existe(articulo.ArticuloId))
        {
            return await Insertar(articulo);
        }
        return await Modificar(articulo);
    }

    /// <summary>
    /// Permite consultar si un articulo existe mediante su Id
    /// </summary>
    /// <param name="ArticuloId"></param>
    /// <returns>True si existe y False si no</returns>
    public async Task<bool> Existe(int ArticuloId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Articulos.AnyAsync(a => a.ArticuloId == ArticuloId);
    }
    
    /// <summary>
    /// Permite insertar un nuevo articulo en la base de datos
    /// </summary>
    /// <param name="articulo"></param>
    /// <returns>Verdadero si es insertado exitosamente y falso si no</returns>
    private async Task<bool> Insertar(Articulos articulo)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        contexto.Articulos.Add(articulo);
        return await contexto.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Permite modificar un articulo en la base de datos
    /// </summary>
    /// <param name="articulo"></param>
    /// <returns>Verdadero si es modificado exitosamente y falso si no</returns>
    private async Task<bool> Modificar(Articulos articulo)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        contexto.Articulos.Update(articulo);
        return await contexto.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Permite eliminar un articulo en la base de datos, utilizando su Id lo busca y si es encontrado lo elimina
    /// </summary>
    /// <param name="ArticuloId"></param>
    /// <returns>Verdadero si fue eliminado y falso si no.</returns>
    public async Task<bool> Eliminar(int ArticuloId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.
            Articulos.
            AsNoTracking().
            Where(a => a.ArticuloId == ArticuloId).
            ExecuteDeleteAsync() > 0;
    }
    
    /// <summary>
    /// Lista los articulos según el criterio que reciba
    /// </summary>
    /// <param name="Criterio"></param>
    /// <returns>Una lista de Articulos que cumplan con el criterio</returns>
    public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> Criterio)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Articulos.AsNoTracking().Where(Criterio).ToListAsync();
    }
    
    /// <summary>
    /// permite buscar un Articulo segun su Id
    /// </summary>
    /// <param name="articuloId"></param>
    /// <returns>Retorna un objeto Articulo</returns>
    public async Task<Articulos?> Buscar(int articuloId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Articulos.FirstOrDefaultAsync(a => a.ArticuloId == articuloId);
    }
}