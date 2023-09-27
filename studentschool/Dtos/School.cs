namespace studentschool.Dtos
{
    public class SchoolUpdateDto
    {
        public int Id { get; set; }
        public string OkulAdi { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
       


    }
    public class SchoolCreateDto
    {
        public string OkulAdi { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }



    }
}
