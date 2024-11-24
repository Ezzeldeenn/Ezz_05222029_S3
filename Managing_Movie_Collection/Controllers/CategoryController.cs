using Managing_Movie_Collection.DTOs;
using Managing_Movie_Collection.Repo.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Managing_Movie_Collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        [HttpPost]
        public IActionResult AddCategory(GetAllCategory_Dto category)
        {
            _categoryRepo.Add(category);
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult Updatecategory(GetAllCategory_Dto category,int id)
        {
            _categoryRepo.Update(category, id);
            return Ok();
        }
         

    }
}
