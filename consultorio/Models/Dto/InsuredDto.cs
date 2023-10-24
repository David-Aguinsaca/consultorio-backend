namespace consultorio.Models.Dto
{
    public class InsuredDto
    {
        public string Identification { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        public ICollection<Sure> Sures { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
