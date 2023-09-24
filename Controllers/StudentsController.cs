using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using students.Repositories;
using studentschool.Models;
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
                 .Where(s => s.Id.Equals(id))
                 .SingleOrDefault()
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
        public IActionResult CreateOneStudent([FromBody] Student student)
        {
            try
            {
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
        public IActionResult UpdateOneStudent([FromRoute(Name = "id")] int id, [FromBody] Student student)
        {
            try
            {
                var entity = _context
                .Students
                .Where(s => s.Id.Equals(id))
                .SingleOrDefault();

                if (entity == null)
                    return NotFound();


                //if (id != student.Id)
                //    return BadRequest();


                entity.Ad = student.Ad;
                entity.Soyad = student.Soyad;
                entity.Sinif = student.Sinif;
                _context.Students.Update(entity);

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
                var entitiy = _context
                .Students
                .Where(s => s.Id.Equals(id))
                .SingleOrDefault();

                if (entitiy is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Girilen id: {id}, Böyle bir id Bulunamadı."
                    });

                _context.Students.Remove(entitiy);
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
