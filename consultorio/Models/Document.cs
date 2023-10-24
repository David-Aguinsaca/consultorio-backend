using System.ComponentModel.DataAnnotations;

namespace consultorio.Models
{
    public class Document
    {
        [Key]
        public int Iddocument { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public int? Idinsured { get; set; }
        public virtual Insured IdinsuredNavigation { get; set; }

    }
}
