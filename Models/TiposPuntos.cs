using System.ComponentModel.DataAnnotations;
using RegistroEstudiante.Enums;

namespace RegistroEstudiante.Models;

public class TiposPuntos
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre debe tener como maximo 50 caracteres")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "La descripcion es obligatoria")]
    [StringLength(200, ErrorMessage = "La descripcion debe tener como maximo 200 caracteres")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El valor en puntos es obligatorio")]
    [RegularExpression(@"^[-]?(10|[1-9])$", ErrorMessage = "Debe ser un número entre -10 y 10, excluyendo 0")]
    public int ValorPuntos { get; set; }

    [Required(ErrorMessage = "El color es obligatorio")]
    public Color Color { get; set; }

    [Required(ErrorMessage = "El icono es obligatorio")]
    public Icon Icono { get; set; }
}