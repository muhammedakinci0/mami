namespace studentschool.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string DersAdi { get; set; }

        public int SchoolId { get; set; }
        public virtual School? School { get; set; }
        public virtual List<Teacher> Teachers { get; set; }


    }
}
