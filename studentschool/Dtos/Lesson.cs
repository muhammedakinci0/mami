namespace studentschool.Dtos
{
    public class LessonUpdateDto
    {
        public int Id { get; set; }
        public string DersAdi { get; set; }

        public int SchoolId { get; set; }
      
        


    }
    public class LessonCreateDto
    {
    
        public string DersAdi { get; set; }

        public int SchoolId { get; set; }




    }
}
