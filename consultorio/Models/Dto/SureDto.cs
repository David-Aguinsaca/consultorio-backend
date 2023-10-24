namespace consultorio.Models.Dto
{
    public class SureDto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public decimal Sumassured { get; set; }

        public decimal Prima { get; set; }

        public ICollection<SureInsured> SureInsureds { get; set; }
    }
}
