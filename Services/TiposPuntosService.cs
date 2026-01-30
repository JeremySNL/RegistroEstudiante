using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using RegistroEstudiante.DAL;
using RegistroEstudiante.Models;
using System.Linq.Expressions;

namespace RegistroEstudiante.Services;

public class TiposPuntosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int tipoPuntoId, String? nombre = null)
    {
        if (nombre == null)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos.AnyAsync(e => e.TipoId == tipoPuntoId);
        }
        else
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.TiposPuntos.AnyAsync(e => e.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && e.TipoId != tipoPuntoId);
        }
    }
    private async Task<bool> Insertar(TiposPuntos tipoPunto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposPuntos.Add(tipoPunto);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(TiposPuntos tipoPunto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposPuntos.Update(tipoPunto);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<TiposPuntos?> Buscar(int tipoPuntoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos.FirstOrDefaultAsync(e => e.TipoId == tipoPuntoId);
    }
    public async Task<bool> Eliminar(int tipoPuntoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos
            .AsNoTracking()
            .Where(e => e.TipoId == tipoPuntoId)
            .ExecuteDeleteAsync() > 0;
    }
    public async Task<List<TiposPuntos>> Listar(Expression<Func<TiposPuntos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<bool> Guardar(TiposPuntos tipoPunto)
    {
        if (!await Existe(tipoPunto.TipoId))
        {
            return await Insertar(tipoPunto);
        }
        else
        {
            return await Modificar(tipoPunto);
        }
    }
}