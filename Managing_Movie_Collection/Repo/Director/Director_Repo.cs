using Managing_Movie_Collection.DTOs;
using Managing_Movie_Collection.Models;
using Microsoft.EntityFrameworkCore;

namespace Managing_Movie_Collection.Repo.Director
{
    public class Director_Repo:IDirector_Repo
    {
        private readonly AppDbContext _context;
        public Director_Repo(AppDbContext context)
        {
            _context = context;
        }

        public void AddDirector(AddDirecotor_Dto direcotor_Dto)
        {
            Models.Director director = new Models.Director
            {
                Name = direcotor_Dto.Name,
                Contact = direcotor_Dto.Contact,
            };
            _context.Directors.Add(director);
            _context.SaveChanges();
        }
        public void AddDirectorwithnationality(GetAllDirecotor_Dto direcotor_Dto)
        {
            Models.Director director = new Models.Director
            {
                Name = direcotor_Dto.Name,
                Contact = direcotor_Dto.Contact,
                Nationality=new Nationality
                {
                    Name=direcotor_Dto.GetAllNationality.Name
                }
            };
            _context.Directors.Add(director);
            _context.SaveChanges();
        }

        public void UpdateDirector(int id, AddDirecotor_Dto direcotor_Dto)
        {
            var dir = _context.Directors.Find(id);
            if (dir == null) {
                throw new Exception("Director Not Found");
            }

                dir.Contact = direcotor_Dto.Contact;
                dir.Name = direcotor_Dto.Name;

            _context.Directors.Update(dir);
            _context.SaveChanges();
        }

        public void UpdateDirectorwithnatonality(int id, GetAllDirecotor_Dto direcotor_Dto)
        {
           var dir= _context.Directors
                .Include(x=>x.Nationality)
                .FirstOrDefault(z=>z.Id==id);
            if (dir == null) {
                throw new Exception($"There is no Director and Nathonality with id Number: {id}");
                 
            }
            else
            {
                dir.Name=direcotor_Dto.Name;
                dir.Contact=direcotor_Dto.Contact;
                dir.Nationality = new Models.Nationality
                {
                    Name = direcotor_Dto.GetAllNationality.Name
                };
            }
            _context.Directors.Update(dir) ;
            _context.SaveChanges();
        }
        public void DeleteDirector(int id) {
            var dir = _context.Directors.Find(id);
            if (dir == null)
                throw new Exception($"There is no Director with id Number: {id}");

            _context.Directors.Remove(dir);
            _context.SaveChanges();

        }
    }
}
