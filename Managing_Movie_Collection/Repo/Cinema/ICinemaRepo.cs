using Managing_Movie_Collection.DTOs;

namespace Managing_Movie_Collection.Repo.Cinema
{
    public interface ICinemaRepo
    {
        List<Getcinemarelation> GetAllCinema();
        void CreateCienema(Getcinemarelation getcinemarelation);
        void UpdateCienema(int id,Getcinemarelation AddDataCienema);
    }
}
