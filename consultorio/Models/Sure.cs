using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace consultorio.Models
{
    public class Sure
    {
        [Key]
        public int Idsure { get; set; }

        [Required(ErrorMessage = "El campo Nombre del Seguro es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Código del Seguro es obligatorio.")]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "El Código del Seguro debe contener solo letras mayúsculas y números.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "El campo Suma Asegurada es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "La Suma Asegurada debe ser mayor que cero.")]
        public decimal Sumassured { get; set; }

        [Required(ErrorMessage = "El campo Prima es obligatorio.")]
        [Precision(18, 2)]
        public decimal Prima { get; set; }

        public ICollection<SureInsured> SureInsureds { get; set; }
    }
}
