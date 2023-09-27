namespace studentschool.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string SinifAdi { get; set; }
        public int SchoolId { get; set; }
        public virtual School? School { get; set; }
        public virtual List<Student> Students { get; set; }
     


    }
}
