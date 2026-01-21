using System.ComponentModel.DataAnnotations;

namespace RegistroEstudiante.Models;
public class Estudiantes
{
    [Key]
    public int EstudianteId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre completo debe tener entre 3 y 100 caracteres")]
    public String Nombres { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "El correo debe ser valido")]
    [Required(ErrorMessage = "El email es obligatorio")]
    public String Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La edad es obligatoria")]
    [Range(1, 120, ErrorMessage = "La edad debe estar entre 15 y 100 años")]
    public int Edad { get; set; }
}
