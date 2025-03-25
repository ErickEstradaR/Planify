using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Planify.DAL;
using Planify.Models;

namespace Planify.Services;

public class ClientesService (IDbContextFactory<Contexto> dbfactory){

    /// <summary>
    /// Este método inserta o modifica un cliente en la base de datos dependiendo de si este existe o no
    /// </summary>
    /// <param name="cliente"></param>
    /// <returns>retorna un bool si la operacion es exitosa y false si falla</returns>
    public async Task<bool> Guardar(Clientes cliente)
    {
        if (!await Existe(cliente.ClienteId))
        {
            return await Insertar(cliente);
        }
        return await Modificar(cliente);
    }

    /// <summary>
    /// Permite consultar si un cliente existe mediante su Id
    /// </summary>
    /// <param name="clienteId"></param>
    /// <returns>True si existe y False si no</returns>
    public async Task<bool> Existe(int clienteId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Clientes.AnyAsync(c => c.ClienteId == clienteId);
    }
    
    /// <summary>
    /// Permite insertar un nuevo cliente en la base de datos
    /// </summary>
    /// <param name="cliente"></param>
    /// <returns>Verdadero si es insertado exitosamente y falso si no</returns>
    private async Task<bool> Insertar(Clientes cliente)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        contexto.Clientes.Add(cliente);
        return await contexto.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Permite modificar un cliente en la base de datos
    /// </summary>
    /// <param name="cliente"></param>
    /// <returns>Verdadero si es modificado exitosamente y falso si no</returns>
    private async Task<bool> Modificar(Clientes cliente)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        contexto.Clientes.Update(cliente);
        return await contexto.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Permite eliminar un cliente en la base de datos, utilizando su Id lo busca y si es encontrado lo elimina
    /// </summary>
    /// <param name="ClienteId"></param>
    /// <returns>Verdadero si fue eliminado y falso si no.</returns>
    public async Task<bool> Eliminar(int ClienteId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.
            Clientes.
            AsNoTracking().
            Where(c => c.ClienteId == ClienteId).
            ExecuteDeleteAsync() > 0;
    }
    
    /// <summary>
    /// Este metodo lista los clientes según el criterio que reciba
    /// </summary>
    /// <param name="Criterio"></param>
    /// <returns>Una lista de clientes que cumplan con el criterio</returns>
    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> Criterio)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Clientes.
            AsNoTracking().Where(Criterio)
            .ToListAsync();
    }
    
    /// <summary>
    /// permite buscar un Cliente segun su Id
    /// </summary>
    /// <param name="ClienteId"></param>
    /// <returns>Retorna un objeto Cliente</returns>
    public async Task<Clientes?> Buscar(int ClienteId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Clientes.FirstOrDefaultAsync(c => c.ClienteId == ClienteId);
    }
}