using Managing_Movie_Collection.DTOs;
using Managing_Movie_Collection.Repo.Director;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Managing_Movie_Collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirector_Repo _Repo;

        public DirectorController(IDirector_Repo repo)
        {
            _Repo = repo;
        }

        [HttpPost("PostDirector")]
        public IActionResult Post(AddDirecotor_Dto director)
        {
            _Repo.AddDirector(director);
            return Created();
        }   

        [HttpPut("UpdateDirectorWithData{id}")]
        public IActionResult Updatedirectorandnathonality(int id, GetAllDirecotor_Dto direcotor_Dto)
        {
            try
            {
                _Repo.UpdateDirectorwithnatonality(id, direcotor_Dto);
                return Accepted();
            }
            catch (Exception ex) { 
             return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DelteDirector(int id)
        {
            try
            {
                _Repo.DeleteDirector(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
