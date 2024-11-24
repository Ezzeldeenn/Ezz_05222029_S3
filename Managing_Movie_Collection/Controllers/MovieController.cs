using Managing_Movie_Collection.DTOs;
using Managing_Movie_Collection.Models;
using Managing_Movie_Collection.Repo.Movie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Managing_Movie_Collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo _repo;
        public MovieController(IMovieRepo movieRepo)
        {
            _repo=movieRepo;
        }
        [HttpGet("Get Movie with Relation Data")]
        public IActionResult GetAll()
        {
            var movie = _repo.GetAllMovies();
            if (!ModelState.IsValid||movie==null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _repo.GetMovieById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("Create new Movie")]
        public IActionResult CreateMovie(GetAllMovie_Dto movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             _repo.CreateMovie(movie);
            return Created();
        }
    }
}
