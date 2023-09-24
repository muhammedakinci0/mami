namespace studentschool.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string SinifAdi { get; set; }
        public virtual List<Student> Students { get; set; }
     


    }
}
