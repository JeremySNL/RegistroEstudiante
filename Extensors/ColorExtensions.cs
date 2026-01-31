using RegistroEstudiante.Enums;

namespace RegistroEstudiante.Extensors;
public static class ColorExtensions
{
    public static string GetCssBgColor(Color color)
    {
        switch(color){
            case Color.Rojo:
                return "bg-danger";
            case Color.Azul:
                return "bg-primary";
            case Color.Verde:
                return "bg-success";
            case Color.Rosa:
                return "#e83e8c";
            case Color.Amarillo:
                return "bg-warning";
            case Color.Gris:
                return ".bg-secondary";
            case Color.Negro:
                return "bg-dark";
            case Color.Blanco:
                return "#bg-light";
            default:
                return "#bg-dark";

        }
    }

    public static string GetCssTextColor(Color color)
    {
        if (color.Equals(Color.Blanco))
        {
            return "text-dark";
        }
        else
        {
            return "text-light";
        }
    }
}
