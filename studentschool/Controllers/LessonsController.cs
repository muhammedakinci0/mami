using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using students.Data;
using students.Repositories;
using System.Security.AccessControl;
using Microsoft.JSInterop;
using System.Numerics;
using studentschool.Models;
using Microsoft.EntityFrameworkCore;
using studentschool.Dtos;

namespace lessons.Controllers
{
    [Route("api/Lessons")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly RepositoryContext _context;
        public LessonsController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllLessons()
        {

            try
            {
                var lessons = _context.Lessons.ToList();


                return Ok(lessons);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneLesson([FromRoute(Name = "id")] int id)
        {
            try
            {
                var lesson = _context
                 .Lessons
                 .Where(s => s.Id.Equals(id)).Include(x => x.Teachers)
                 .SingleOrDefault()
                 ;


                if (lesson == null)
                {
                    return NotFound();
                }
                return Ok(lesson);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOneLesson([FromBody] LessonCreateDto input)
        {
            try
            {
                Lesson lesson = new Lesson {
                 DersAdi = input.DersAdi,
                  SchoolId = input.SchoolId,

                };
                if (lesson is null)
                    return BadRequest();
                _context.Lessons.Add(lesson);
                _context.SaveChanges();
                return StatusCode(201, lesson);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneLesson([FromRoute(Name = "id")] int id, [FromBody] LessonUpdateDto input)
        {
            try
            {
                Lesson lesson = new Lesson
                {
                    Id = id,
                     SchoolId=input.SchoolId,
                     DersAdi=input.DersAdi,
                     
                };

               

                if (lesson == null)
                    return NotFound();


                if (id != lesson.Id)
                    return BadRequest();






                
               
                


                _context.Lessons.Update(lesson);

                _context.SaveChanges();

                return Ok(lesson);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneLesson([FromRoute(Name = "id")] int id)
        {
            try
            {
                Lesson lesson = new Lesson { Id = id };

                if (lesson is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Girilen id: {id}, Böyle bir id Bulunamadı."
                    });

                _context.Lessons.Remove(lesson);
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
