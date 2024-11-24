using Managing_Movie_Collection.DTOs;
using Managing_Movie_Collection.Repo.Natinality;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Managing_Movie_Collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NathonalityController : ControllerBase
    {
        private readonly INatonalityRepo _repo;
        public NathonalityController(INatonalityRepo natonalityRepo)
        {
            
            _repo = natonalityRepo;
        }

        [HttpPost("AddNathonality")]
        public IActionResult AddNathonality(GetAllNationality_Dto nationality_Dto)
        {
            _repo.AddNathonality(nationality_Dto);
            return Created();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNathonality(int id)
        {
            try
            {
                _repo.DeleteNathonality(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
