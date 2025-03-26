using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Planify.Data;
using Planify.Models;

namespace Planify.Services;

public class EventosService (IDbContextFactory<ApplicationDbContext> dbfactory)
{
    /// <summary>
    /// Este método inserta o modifica un evento en la base de datos dependiendo de si este existe o no
    /// </summary>
    /// <param name="evento"></param>
    /// <returns>retorna un bool si la operacion es exitosa y false si falla</returns>
    public async Task<bool> Guardar(Eventos evento)
    {
        if (!await Existe(evento.ClienteId))
        {
            return await Insertar(evento);
        }
        return await Modificar(evento);
    }

    /// <summary>
    /// Permite consultar si un evento existe mediante su Id
    /// </summary>
    /// <param name="eventoId"></param>
    /// <returns>True si existe y False si no</returns>
    public async Task<bool> Existe(int eventoId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Eventos.AnyAsync(e=>e.EventoId==eventoId);
    }
    
    /// <summary>
    /// Permite insertar un nuevo evento en la base de datos
    /// </summary>
    /// <param name="evento"></param>
    /// <returns>Verdadero si es insertado exitosamente y falso si no</returns>
    private async Task<bool> Insertar(Eventos evento)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        contexto.Eventos.Add(evento);
        return await contexto.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Permite modificar un cliente en la base de datos
    /// </summary>
    /// <param name="cliente"></param>
    /// <returns>Verdadero si es modificado exitosamente y falso si no</returns>
    private async Task<bool> Modificar(Eventos evento)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        contexto.Eventos.Update(evento);
        return await contexto.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Permite eliminar un cliente en la base de datos, utilizando su Id lo busca y si es encontrado lo elimina
    /// </summary>
    /// <param name="ClienteId"></param>
    /// <returns>Verdadero si fue eliminado y falso si no.</returns>
    public async Task<bool> Eliminar(int EventoId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.
            Eventos.
            AsNoTracking().
            Where(e => e.EventoId == EventoId).
            ExecuteDeleteAsync() > 0;
    }
    
    /// <summary>
    /// Este metodo lista los eventos según el criterio que reciba
    /// </summary>
    /// <param name="Criterio"></param>
    /// <returns>Una lista de eventos que cumplan con el criterio</returns>
    public async Task<List<Eventos>> Listar(Expression<Func<Eventos, bool>> Criterio)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Eventos.
            AsNoTracking().Where(Criterio)
            .ToListAsync();
    }
    
    /// <summary>
    /// permite buscar un evento segun su Id
    /// </summary>
    /// <param name="EventoId"></param>
    /// <returns>Retorna un objeto Evento</returns>
    public async Task<Eventos?> Buscar(int EventoId)
    {
        await using var contexto = await dbfactory.CreateDbContextAsync();
        return await contexto.Eventos.FirstOrDefaultAsync(e=>e.EventoId == EventoId);
    }
}