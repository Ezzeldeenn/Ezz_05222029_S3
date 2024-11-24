using Managing_Movie_Collection.DTOs;
using Managing_Movie_Collection.Models;

namespace Managing_Movie_Collection.Repo.Category
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Add(GetAllCategory_Dto categoryDto)
        {
            var cat = new Models.Category
            {
                Name = categoryDto.Name,
            };
            _context.Categories.Add(cat);
            _context.SaveChanges();
        }

        public void Update(GetAllCategory_Dto categoryDto, int Id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == Id);
            if (category != null)
            {
                category.Name = categoryDto.Name;
            }
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}



//Category/(ICategoryRepo.cs,CategoryRepo.cs)