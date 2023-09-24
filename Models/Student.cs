namespace studentschool.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Sinif { get; set; }
        public int SchoolId { get; set; }
        public int ClassesId { get; set; }
        public virtual School School { get; set; }
        public virtual Classes  Classes { get; set; }



    }
}
