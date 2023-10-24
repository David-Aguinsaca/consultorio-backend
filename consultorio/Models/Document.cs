using System.ComponentModel.DataAnnotations;

namespace consultorio.Models
{
    public class Document
    {
        [Key]
        public int Iddocument { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        public string Url { get; set; }
        public string? Description { get; set; }
        public string? Extenextension { get; set; }
        public int? Idinsured { get; set; }
        public virtual Insured IdinsuredNavigation { get; set; }

    }
}
