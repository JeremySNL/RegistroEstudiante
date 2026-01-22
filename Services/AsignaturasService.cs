using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using RegistroEstudiante.DAL;
using RegistroEstudiante.Models;
using System.Linq.Expressions;

namespace RegistroEstudiante.Services;

public class AsignaturasService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int asignaturaId, String? nombre = null)
    {
        if (nombre == null)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.AnyAsync(e => e.AsignaturaId == asignaturaId);
        }
        else
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.AnyAsync(e => e.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && e.AsignaturaId != asignaturaId);
        }
    }
    private async Task<bool> Insertar(Asignaturas asignatura)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Asignaturas.Add(asignatura);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Asignaturas asignatura)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Asignaturas.Update(asignatura);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<Asignaturas?> Buscar(int asignaturaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Asignaturas.FirstOrDefaultAsync(e => e.AsignaturaId == asignaturaId);
    }
    public async Task<bool> Eliminar(int asignaturaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Asignaturas
            .AsNoTracking()
            .Where(e => e.AsignaturaId == asignaturaId)
            .ExecuteDeleteAsync() > 0;
    }
    public async Task<List<Asignaturas>> Listar(Expression<Func<Asignaturas, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Asignaturas
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<bool> Guardar(Asignaturas asignatura)
    {
        if (!await Existe(asignatura.AsignaturaId))
        {
            return await Insertar(asignatura);
        }
        else
        {
            return await Modificar(asignatura);
        }
    }
}