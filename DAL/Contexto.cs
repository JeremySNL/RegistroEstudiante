using RegistroEstudiante.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroEstudiante.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Estudiantes> Estudiantes { get; set; }
    }
}
