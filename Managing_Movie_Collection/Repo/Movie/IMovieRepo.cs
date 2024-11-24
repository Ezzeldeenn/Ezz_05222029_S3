using Managing_Movie_Collection.Models;

namespace Managing_Movie_Collection.Repo.Movie
{
    public interface IMovieRepo
    {
      List<GetAllMovie_Dto> GetAllMovies();
      GetAllMovie_Dto GetMovieById(int id); 
      void CreateMovie(GetAllMovie_Dto getAllMovie_Dto);
    }
}
