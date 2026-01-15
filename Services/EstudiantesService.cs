//using RegistroEstudiante.;
using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.DAL;
using RegistroEstudiante.Models;
using System.Linq.Expressions;

namespace RegistroEstudiante.Services
{
    public class EstudiantesService(IDbContextFactory<Contexto> DbFactory)
    {
        private async Task<bool> Existe(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.AnyAsync(e => e.EstudianteId == estudianteId);
        }
        private async Task<bool> Insertar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Estudiantes.Add(estudiante);
            return await contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Estudiantes.Update(estudiante);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<Estudiantes?> Buscar(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.FirstOrDefaultAsync(e => e.EstudianteId == estudianteId);
        }
        public async Task<bool> Eliminar(int estudianteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.AsNoTracking().Where(e => e.EstudianteId == estudianteId).ExecuteDeleteAsync() > 0;
        }
        public async Task<List<Estudiantes>> Listar()
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.ToListAsync();
        }
        public async Task<bool> Guardar(Estudiantes estudiante)
        {
            if (!await Existe(estudiante.EstudianteId))
            {
                return await Insertar(estudiante);
            }
            else
            {
                return await Modificar(estudiante);
            }
        }
    }
}
