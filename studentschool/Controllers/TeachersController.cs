using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using students.Data;
using students.Repositories;
using System.Security.AccessControl;
using Microsoft.JSInterop;
using System.Numerics;
using studentschool.Models;
using studentschool.Dtos;

namespace teachers.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly RepositoryContext _context;
        public TeachersController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllTeachers()
        {

            try
            {
                var teachers = _context.Teachers.ToList();


                return Ok(teachers);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneTeacher([FromRoute(Name = "id")] int id)
        {
            try
            {
                var teachers = _context
                 .Teachers
                 .Where(s => s.Id.Equals(id))
                 .SingleOrDefault();

                if (teachers == null)
                {
                    return NotFound();
                }
                return Ok(teachers);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOneTeacher([FromBody] TeacherCreateDto input)
        {
            try
            {
                Teacher teacher = new Teacher
                {
                    Isim = input.Isim,
                    Soyisim = input.Soyisim,
                    LessonId = input.LessonId,
                    SchoolId = input.SchoolId,
                };
                if (input is null)
                    return BadRequest();






                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return StatusCode(201, teacher);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneTeacher([FromRoute(Name = "id")] int id, [FromBody] TeacherUpdateDto input)
        {
            try
            {
                Teacher teacher = new Teacher
                {
                    Id = id,
                    Isim = input.Isim,
                    Soyisim = input.Soyisim,
                    LessonId = input.LessonId,
                    SchoolId = input.SchoolId,

                };


                if (teacher == null)
                    return NotFound();


                if (id != teacher.Id)
                    return BadRequest();












                _context.Teachers.Update(teacher);

                _context.SaveChanges();

                return Ok(teacher);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneTeacher([FromRoute(Name = "id")] int id)
        {
            try
            {
                Teacher teacher = new Teacher
                {
                    Id = id,
                };
                if (teacher is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Girilen id: {id}, Böyle bir id Bulunamadı."
                    });
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }

}
