using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices _movieServices;
        public MovieController (IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_movieServices.GetAll());
        }

        [HttpGet("GetById{id}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            return Ok(_movieServices.GetMovieById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] MovieCreateRequest movieDto)
        {
            _movieServices.Create(movieDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] MovieUpdateRequest movieDto,[FromRoute] int id)
        {
            _movieServices.UpdateMovie(movieDto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            _movieServices.Delete(id);
            return Ok();
        }
    }
}
