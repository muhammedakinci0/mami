namespace studentschool.Dtos
{
    public class TeacherUpdateDto
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public int SchoolId { get; set; }

        public int LessonId { get; set; }


    }
    public class TeacherCreateDto
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public int SchoolId { get; set; }

        public int LessonId { get; set; }


    }
}
