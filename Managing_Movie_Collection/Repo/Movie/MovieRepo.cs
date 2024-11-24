using Managing_Movie_Collection.DTOs;
using Managing_Movie_Collection.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Managing_Movie_Collection.Repo.Movie
{
    public class MovieRepo : IMovieRepo
    {
        private readonly AppDbContext _context;
        public MovieRepo(AppDbContext context)
        {
            _context=context;
        }

        public void CreateMovie(GetAllMovie_Dto getAllMovie_Dto)
        {
            var movie = new Models.Movie
            {
                Title = getAllMovie_Dto.Title,
                ReleseYear = getAllMovie_Dto.ReleseYear,
                Category = new Models.Category
                {
                    Name = getAllMovie_Dto.Category_Dto.Name,
                },
                Cinema = new Models.Cinema
                {
                    Name =getAllMovie_Dto.CinemaDto.Name,
                    Placehorder=getAllMovie_Dto.CinemaDto.Placehorder
                },
                Directors = getAllMovie_Dto.Direcotor_Dtos
                      .Select(x =>
                       new Models.Director
                       {
                           Contact = x.Contact,
                           Name = x.Name,
                           Nationality = new Nationality
                           {
                               Name = x.GetAllNationality.Name,
                           }
                       }).ToList()
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public List<GetAllMovie_Dto> GetAllMovies()
        {
            var Movie = _context.Movies.Include(x => x.Category)
                .Include(x => x.Directors)
                .ThenInclude(x => x.Nationality)
                .Select(
                x => new GetAllMovie_Dto
                {
                    Title= x.Title,
                    ReleseYear= x.ReleseYear,
                    Category_Dto=new GetAllCategory_Dto
                    {
                        Name=x.Category.Name,
                    },
                    CinemaDto=new GetAllCinemaDto
                    {
                        Name=x.Cinema.Name,
                         Placehorder=x.Cinema.Placehorder
                    }
                    ,
                    Direcotor_Dtos = x.Directors.Select(
                        x=>new GetAllDirecotor_Dto
                        {
                        Name=x.Name,
                        Contact=x.Contact,  
                        GetAllNationality=new GetAllNationality_Dto
                        {
                            Name=x.Nationality.Name,
                        }
                    }).ToList(),
                }
                ).ToList();
            return Movie;
        }

        GetAllMovie_Dto IMovieRepo.GetMovieById(int id)
        {
            var values = _context.Movies.Include(x => x.Category)
                .Include(x => x.Directors)
                .ThenInclude(x => x.Nationality)
                .Where(x => x.Id == id).Select(                
                x=>new GetAllMovie_Dto
                {
                    Title = x.Title,
                    ReleseYear = x.ReleseYear,
                    Category_Dto = new GetAllCategory_Dto
                    {
                        Name = x.Category.Name,
                    },
                    CinemaDto=new GetAllCinemaDto
                    {
                        Name=x.Cinema.Name,
                        Placehorder=x.Cinema.Placehorder
                    }
                    ,
                    Direcotor_Dtos = x.Directors.Select(
                  z => new GetAllDirecotor_Dto
                  {
                      Contact = z.Contact,
                      Name = z.Name,
                      GetAllNationality = new GetAllNationality_Dto
                      {
                          Name = z.Nationality.Name,
                      }
                  }).ToList()
                }).FirstOrDefault();

            return values;
        }

    }
}
