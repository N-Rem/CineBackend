using Application.Interfaces;
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
        public IActionResult GetShowsByMovieId(int movieId)
        {
            var list = _showService.GetShowsByMovieId(movieId);

            if(list == null) 
                return Ok();

            return NotFound();
        }

        [HttpPut("[action]")]
        public IActionResult ModifyShow(int idShow, string startTime, string date, string price)
        {
            if(_showService.ModifyShow(idShow, startTime, date, price)) 
                return Ok();

            return NotFound();
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteShow(int idShow)
        {
            if(_showService.DeleteShow(idShow))
                return Ok();

            return NotFound();
        }

        [HttpPost("[action]")]
        public IActionResult AddShow(string startTime, string date, string price, int movieId)
        {
            _showService.AddShow(startTime, date, price, movieId);
            return Ok();
        }
    }
}
