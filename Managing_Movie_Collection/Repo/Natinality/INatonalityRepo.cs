using Managing_Movie_Collection.DTOs;

namespace Managing_Movie_Collection.Repo.Natinality
{
    public interface INatonalityRepo
    {
        void AddNathonality(GetAllNationality_Dto nationality_Dto);
        void DeleteNathonality(int id); 
    }
}
