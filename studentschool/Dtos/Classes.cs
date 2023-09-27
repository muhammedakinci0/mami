namespace studentschool.Dtos
{
    public class ClassesCreateDto
    {    
        public string SinifAdi { get; set; }
        public int SchoolId { get; set; }
    }

    public class ClassesUpdateDto
    {
        public int Id { get; set; }
        public string SinifAdi { get; set; }
        public int SchoolId { get; set; }
    }

}
