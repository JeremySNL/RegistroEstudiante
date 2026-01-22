using System.ComponentModel.DataAnnotations;

namespace RegistroEstudiante.Models;
public class Asignaturas
{
    [Key]
    public int AsignaturaId { get; set; }

    [RegularExpression(@"^(ISC|HUM|MAT|QMA|FIS|ORI|EC|CS|ECO|CNT|IC|ADM)-\d{3}$", ErrorMessage = "El código debe tener un formato correcto. Ej: ISC-101, MAT-205")]
    [Required(ErrorMessage = "El código de la asignatura es obligatorio")]
    public String Codigo { get; set; }

    [Required(ErrorMessage = "El nombre de la asignatura es obligatorio")]
    [StringLength(75, ErrorMessage = "El nombre de la asignatura debe tener maximo 75 caracteres")]
    public String Nombre { get; set; }

    [Required(ErrorMessage = "El aula es obligatoria")]
    [RegularExpression(@"^[ABCPM]-[1-4]\d{2}$", ErrorMessage = "El aula debe tener un formato correcto. Ej: A-201")]
    public String Aula { get; set; }

    [Required(ErrorMessage = "La cantidad de créditos es obligatoria")]
    [Range(1, 5, ErrorMessage = "Los créditos deben estar entre 1 y 5")]
    public int Creditos { get; set; }
}
