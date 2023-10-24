using System.ComponentModel.DataAnnotations;

namespace consultorio.Models
{
    public class Insured
    {

        [Key]
        public int Idinsured { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        [RegularExpression(@"^\d{9,12}$", ErrorMessage = "La Cédula debe contener entre 9 y 12 dígitos.")]
        public string Identification { get; set; }

        [Required(ErrorMessage = "El campo Nombre del Cliente es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [RegularExpression(@"^\d{8,12}$", ErrorMessage = "El Teléfono debe contener entre 8 y 12 dígitos.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "El campo Edad es obligatorio.")]
        [Range(18, 80, ErrorMessage = "La Edad debe estar entre 18 y 80 años.")]
        public int Age { get; set; }

        public ICollection<SureInsured> SureInsureds { get; set; }
        public ICollection<Document> Documents { get; set; }

    }
}
