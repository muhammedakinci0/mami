namespace studentschool.Models
{
    public class School
    {
        public int Id { get; set; }
        public string OkulAdi { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public virtual List<Lesson> Lessons { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Teacher>  Teachers { get; set; }
        public virtual List<Classes>  Classes { get; set; }


    }
}
