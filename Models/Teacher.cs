namespace studentschool.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public int SchoolId { get; set; }
        public virtual School? School { get; set; }
        public int LessonId { get; set; }
        
        public virtual Lesson?  Lesson { get; set; }
    }
}
