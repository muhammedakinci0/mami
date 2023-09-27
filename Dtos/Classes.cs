namespace studentschool.Dtos
{
    public class ClassCreateDto
    {    
        public string SinifAdi { get; set; }
        public int SchoolId { get; set; }
    }

    public class ClassUpdateDto
    {
        public int Id { get; set; }
        public string SinifAdi { get; set; }
        public int SchoolId { get; set; }
    }

}
