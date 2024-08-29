using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService=showService;
        }   

        [HttpGet("[action]")]
        public IActionResult GetShowsByMovieId([FromRoute] int movieId)
        {
            var list = _showService.GetShowsByMovieId(movieId);

            if(list is not null) 
                return Ok(list);

            return NotFound();
        }

        [HttpPut("[action]")]
        public IActionResult ModifyShow([FromRoute] int idShow, [FromBody] ShowDto show)
        {
            if(_showService.ModifyShow(idShow, show)) 
                return Ok();

            return NotFound();
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteShow([FromRoute] int idShow)
        {
            if(_showService.DeleteShow(idShow))
                return Ok();

            return NotFound();
        }

        [HttpPost("[action]")]
        public IActionResult AddShow([FromBody] string startTime, string date, string price, int movieId)
        {
            _showService.AddShow(startTime, date, price, movieId);
            return Ok();
        }
    }
}
