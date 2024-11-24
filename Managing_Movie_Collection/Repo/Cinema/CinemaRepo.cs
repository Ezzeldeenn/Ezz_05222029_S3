using Managing_Movie_Collection.DTOs;
using Managing_Movie_Collection.Models;
using Microsoft.EntityFrameworkCore;

namespace Managing_Movie_Collection.Repo.Cinema
{
    public class CinemaRepo:ICinemaRepo
    {
        private readonly AppDbContext _context;
        public CinemaRepo(AppDbContext context)
        {
             _context = context;
        }

        public void CreateCienema(Getcinemarelation getcinemarelation)
        {
            var cienma=new Models.Cinema
            {
                Name = getcinemarelation.Name,
                Placehorder = getcinemarelation.Placehorder,
                Movies=getcinemarelation.Dataformovie.Select(
                    x=>new Models.Movie
                    {
                        Title = x.Title,
                        ReleseYear=x.ReleseYear,
                        Category=new Models.Category
                        {
                            Name=x.Category_Dto.Name,
                        },
                        Directors=x.Direcotor_Dtos.Select(
                            x=>new Models.Director
                            {
                                Name=x.Name,
                                Contact=x.Contact,
                                Nationality=new Nationality
                                {
                                    Name=x.GetAllNationality.Name,
                                }
                            }
                            ).ToList(),
                    }
                    ).ToList(),
            };
            _context.Cinemas.Add( cienma );
            _context.SaveChanges();
        }

        public List<Getcinemarelation> GetAllCinema()
        {
            var AllData = _context.Cinemas
                .Include(x => x.Movies)
                .ThenInclude(x => x.Directors)
                .ThenInclude(x => x.Nationality)
                .Include(x => x.Movies)
                .ThenInclude(x => x.Category)
                .Select(
                x => new Getcinemarelation
                {
                    Name = x.Name,
                    Placehorder = x.Placehorder,
                    Dataformovie = x.Movies.Select(
                        x=>new Getdataforcinema
                        {
                            Title = x.Title,
                            ReleseYear=x.ReleseYear,
                            Direcotor_Dtos=x.Directors.Select(
                                x=>new GetAllDirecotor_Dto
                                {
                                    Name=x.Name,
                                    Contact=x.Contact,
                                    GetAllNationality=new GetAllNationality_Dto
                                    {
                                        Name= x.Nationality.Name,
                                    }                            
                                }).ToList(),
                            Category_Dto=new GetAllCategory_Dto
                            {
                                Name=x.Category.Name,
                            }
                        }).ToList(),
                }).ToList(); 
            return AllData;
        }

        public void UpdateCienema(int id,Getcinemarelation AddDataCienema)
        {
            var AllData = _context.Cinemas
                .Include(x => x.Movies)
                .ThenInclude(x => x.Directors)
                .ThenInclude(x => x.Nationality)
                .Include(x => x.Movies)
                .ThenInclude(x => x.Category).FirstOrDefault(x => x.Id==id);
            if (AllData == null)
            {
                throw new Exception($"There is no cienma With this {id}");
            }
            else
            {
                AllData.Name= AddDataCienema.Name;
                AllData.Placehorder= AddDataCienema.Placehorder;
                AllData.Movies = AddDataCienema.Dataformovie.Select(
                    x => new Models.Movie
                    {
                        Title = x.Title,
                        ReleseYear = x.ReleseYear,
                        Category=new Models.Category
                        {
                            Name=x.Category_Dto.Name,
                        },
                        Directors=x.Direcotor_Dtos.Select(
                            x=>new Models.Director
                            {
                                Contact=x.Contact,
                                Name=x.Name,
                                Nationality=new Nationality
                                {
                                    Name = x.GetAllNationality.Name
                                }
                            }
                            ).ToList(),
                    }
                    ).ToList();
            }
            _context.Cinemas.Update( AllData );
            _context.SaveChanges();
        }
    }
}
