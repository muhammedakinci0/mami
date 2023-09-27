using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using students.Repositories;
using studentschool.Models;
using studentschool.Dtos;
using System.Security.AccessControl;

namespace classes.controller
{
    [Route("api/Classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly RepositoryContext _context;
        public ClassesController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllClasses()
        {
            try
            {
                var classes = _context.Classes.ToList();
                return Ok(classes);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneClasses([FromRoute(Name = "id")] int id)
        {
            try
            {
                var classes = _context
                 .Classes
                 .Where(s => s.Id.Equals(id))
                 .SingleOrDefault();
                ;


                if (classes == null)
                {
                    return NotFound();
                }
                return Ok(classes);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOneClasses([FromBody] ClassesCreateDto input)
        {
            try
            {

                Classes classes = new Classes
                {
                     SinifAdi = input.SinifAdi,

                     SchoolId = input.SchoolId,
                };


                if (classes is null)
                    return BadRequest();


                _context.Classes.Add(classes);
                _context.SaveChanges();
                return StatusCode(201, classes);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneStudent([FromRoute(Name = "id")] int id, [FromBody] ClassesUpdateDto input)
        {
            try
            {
                Classes classes = new Classes
                {
                    Id = id,
                     SchoolId=input.SchoolId,
                      SinifAdi=input.SinifAdi,
                };



                if (classes == null)
                    return NotFound();
                _context.Classes.Update(classes);

                _context.SaveChanges();

                return Ok(classes);
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
                Classes classes = new Classes
                {
                    Id = id
                };

                if (classes is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Girilen id: {id}, Böyle bir id Bulunamadı."
                    });

                _context.Classes.Remove(classes);
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
