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

namespace schools.Controllers
{
    [Route("api/Schools")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly RepositoryContext _context;
        public SchoolsController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllSchools()
        {

            try
            {
                var schools = _context.Schools.ToList();


                return Ok(schools);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneSchool([FromRoute(Name = "id")] int id)
        {
            try
            {
                var school = _context
                 .Schools
                 .Where(s => s.Id.Equals(id)).Include(x => x.Students)
                 .SingleOrDefault()
                 ;


                if (school == null)
                {
                    return NotFound();
                }
                return Ok(school);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOneSchool([FromBody] SchoolCreateDto input)
        {
            try

            {
                School school = new School
                {
                    Il = input.Il,
                    Ilce = input.Ilce,
                    OkulAdi = input.OkulAdi,
                };
                if (school is null)
                    return BadRequest();
                _context.Schools.Add(school);
                _context.SaveChanges();
                return StatusCode(201, school);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateOneSchool([FromRoute(Name = "id")] int id, [FromBody] SchoolUpdateDto input)
        {
            try
            {
                School school = new School {
                 Id = id,
                 Il = input.Il,
                 Ilce = input.Ilce,
                 OkulAdi=input.OkulAdi,
                };

                

                if (school == null)
                    return NotFound();


                if (id != school.Id)
                    return BadRequest();

               

                


               
                

                _context.Schools.Update(school);

                _context.SaveChanges();

                return Ok(school);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneSchool([FromRoute(Name = "id")] int id)
        {
            try
            {
                School school = new School {
                    Id = id };

                if (school is null)
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = $"Girilen id: {id}, Böyle bir id Bulunamadı."
                    }) ;

                _context.Schools.Remove(school);
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
