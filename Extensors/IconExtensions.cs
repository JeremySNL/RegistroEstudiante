using RegistroEstudiante.Enums;

namespace RegistroEstudiante.Extensors;
public static class IconExtensions
{
    public static string GetCssIcon(Icon icono)
    {
        switch (icono)
        {
            case Icon.PulgarArriba:
                return "bi-hand-thumbs-up-fill text-success";
            case Icon.Logro:
                return "bi-award-fill text-warning";
            case Icon.Destacado:
                return "bi-star-fill text-warning";
            case Icon.Error:
                return "bi-x-circle-fill text-danger";
            case Icon.Advertencia:
                return "bi-exclamation-triangle-fill text-warning";
            case Icon.PulgarAbajo:
                return "bi-hand-thumbs-down-fill text-danger";
            case Icon.Pregunta:
                return "bi-question-circle-fill text-warning";
            case Icon.Participacion:
                return "bi-chat-dots-fill text-primary";
            case Icon.Reloj:
                return "bi-clock-fill text-warning";
            default:
                return "";
        }
    }
}
