namespace studentschool.Dtos
{
    public class StudentUpdateDto
    {

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Sinif { get; set; }
        public int SchoolId { get; set; }
        public int ClassesId { get; set; }



    }
    public class StudentCreateDto
    {

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Sinif { get; set; }
        public int SchoolId { get; set; }
        public int ClassesId { get; set; }



    }
}
