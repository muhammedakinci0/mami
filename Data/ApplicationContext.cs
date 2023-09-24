
using studentschool.Models;
using System.Numerics;

namespace students.Data
{
    public static class ApplicationContext
    {
        public static List<Student> Students { get; set; }
        public static List<School> Schools { get; set; }
        public static List<Lesson> Lessons { get; set; }
        public static List<Teacher> Teachers { get; set; }

    }
}
