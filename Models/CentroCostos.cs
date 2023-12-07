using System.ComponentModel.DataAnnotations;

namespace Ejemplo1.Models
{
    public class CentroCostos
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "El código del centro de costos es requerido")]
        public int Codigo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre del centro de costos es requerido")]
        public string NombreCentroCostos { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El mensaje del centro de costos es requerido")]
        public string Mensaje { get; set; }

    }
}
