using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorServices _directorService;

        public DirectorsController(IDirectorServices directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Director>> GetDirectors()
        {
            var directors = _directorService.GetAllDirectors();
            return Ok(directors);
        }

        [HttpGet("{id}")]
        public ActionResult<Director> GetDirector(int id)
        {
            var director = _directorService.GetDirectorById(id);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

        [HttpGet("byname/{name}")]
        public ActionResult<Director> GetDirectorByName(string name)
        {
            var director = _directorService.GetDirectorByName(name);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

        [HttpPost]
        public ActionResult<Director> CreateDirector([FromBody] Director director)
        {
            var createdDirector = _directorService.AddDirector(director);
            return CreatedAtAction(nameof(GetDirector), new { id = createdDirector.Id }, createdDirector);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] Director director)
        {
            if (id != director.Id)
            {
                return BadRequest();
            }

            try
            {
                _directorService.UpdateDirector(director);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            try
            {
                _directorService.DeleteDirector(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

