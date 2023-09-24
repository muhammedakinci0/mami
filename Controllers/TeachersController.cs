using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using students.Data;
using students.Repositories;
using System.Security.AccessControl;
using Microsoft.JSInterop;
using System.Numerics;
using studentschool.Models;

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
        public IActionResult CreateOneTeacher([FromBody] Teacher teacher)
        {
            try
            {
                if (teacher is null)
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
        public IActionResult UpdateOneTeacher([FromRoute(Name = "id")] int id, [FromBody] Teacher teacher)
        {
            try
            {
                var entity = _context
                .Teachers
                .Where(s => s.Id.Equals(id))
                .SingleOrDefault();

                if (entity == null)
                    return NotFound();


                if (id != teacher.Id)
                    return BadRequest();






                entity.Isim = teacher.Isim;
                entity.Soyisim = teacher.Soyisim;
                //entity.Ders = teacher.Ders;
               
                


                _context.Teachers.Update(entity);

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
                var entitiy = _context
                .Teachers
                .Where(s => s.Id.Equals(id))
                .SingleOrDefault();

                if (entitiy is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Girilen id: {id}, Böyle bir id Bulunamadı."
                    });

                _context.Teachers.Remove(entitiy);
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
