using System.ComponentModel.DataAnnotations;

namespace RegistroEstudiante.Models
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public String Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        public String Email { get; set; } = string.Empty;
    }
}
