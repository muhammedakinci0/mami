using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using studentschool.Models;

namespace students.Repositories.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student { Id = 1, Ad = "Muhammed", Soyad = "Akıncı", Sinif = 12, SchoolId=1,ClassesId=1 },
                new Student { Id = 2, Ad = "Arda", Soyad = "Tekin", Sinif = 11 ,SchoolId = 1, ClassesId = 1 },
                new Student { Id = 3, Ad = "Ahmet", Soyad = "Sülü", Sinif = 14,SchoolId=1, ClassesId = 1 }
            );
        }
    }
    public class SchoolConfig : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasData(
                new School { Id = 1, OkulAdi = "FSM Lisesi", Il = "Istanbul", Ilce = "Maltepe" }

            );
        }
    }
    public class ClassesConfig : IEntityTypeConfiguration<Classes>
    {
        public void Configure(EntityTypeBuilder<Classes> builder)
        {
            builder.HasData(
                new Classes { Id = 1,  SinifAdi = "12-A", SchoolId=1}

            );
        }
    }
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasData(
                new Teacher { Id = 1, Isim = "Yunus", Soyisim = "Temel", SchoolId = 1, LessonId = 1 }

            );
        }
    }
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasData(
                new Lesson { Id = 1,  DersAdi = "matematik", SchoolId = 1 }

            );
        }
    }
}
