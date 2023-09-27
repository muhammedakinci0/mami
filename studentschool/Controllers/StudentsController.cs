using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using students.Repositories;
using studentschool.Models;
using studentschool.Dtos;
using System.Security.AccessControl;

namespace students.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly RepositoryContext _context;
        public StudentsController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _context.Students.ToList();
                return Ok(students);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneStudent([FromRoute(Name = "id")] int id)
        {
            try
            {
                
                var student = _context
                 .Students
                 .Where(s => s.Id.Equals(id)).Include(x => x.School)
                 .SingleOrDefault();
                ;


                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOneStudent([FromBody] StudentCreateDto input)
        {
            try
            {

                Student student = new Student
                {
                    Ad = input.Ad,
                    Soyad = input.Soyad,
                    SchoolId = input.SchoolId,
                    ClassesId = input.ClassesId,
                    Sinif = input.Sinif
                };


                if (student is null)
                    return BadRequest();


                _context.Students.Add(student);
                _context.SaveChanges();
                return StatusCode(201, student);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneStudent([FromRoute(Name = "id")] int id, [FromBody] StudentUpdateDto input)
        {
            try
            {
                Student student = new Student
                {
                    Id = id,
                    Ad = input.Ad,
                    Soyad = input.Soyad,
                    ClassesId = (int)input.ClassesId,
                    SchoolId = (int)input.SchoolId,
                    Sinif = (int)input.Sinif
                };



                if (student == null)
                    return NotFound();
                _context.Students.Update(student);

                _context.SaveChanges();

                return Ok(student);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }



        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneStudent([FromRoute(Name = "id")] int id)
        {
            try
            {
                Student student = new Student
                {
                    Id = id
                };

                if (student is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Girilen id: {id}, Böyle bir id Bulunamadı."
                    });

                _context.Students.Remove(student);
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
