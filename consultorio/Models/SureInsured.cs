namespace consultorio.Models
{
    public class SureInsured
    {
        public int Idinsured { get; set; }
        public Insured Insured { get; set; }

        public int Idsure { get; set; }
        public Sure Sure { get; set; }
    }
}
