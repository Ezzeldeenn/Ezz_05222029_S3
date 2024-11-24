using Managing_Movie_Collection.DTOs;
using Managing_Movie_Collection.Models;
using Managing_Movie_Collection.Repo.Cinema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Managing_Movie_Collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaRepo _repo;
        public CinemaController(ICinemaRepo repo)
        {
            _repo = repo;   
        }
        [HttpGet("Get All Data")]
        public IActionResult Get()
        {
            var GetData = _repo.GetAllCinema();
            if (GetData == null) 
            return NoContent();

            return Ok(GetData);
        }
        [HttpPost("Add New Cinema")]
        public IActionResult Post(Getcinemarelation Cinema)
        {
            _repo.CreateCienema(Cinema);
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCiema(int id , Getcinemarelation cienma)
        {
            try
            {
                _repo.UpdateCienema(id, cienma);
                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
