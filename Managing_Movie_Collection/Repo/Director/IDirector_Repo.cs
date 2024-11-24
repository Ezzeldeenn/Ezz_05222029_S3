using Managing_Movie_Collection.DTOs;

namespace Managing_Movie_Collection.Repo.Director
{
    public interface IDirector_Repo
    {
        void AddDirector(AddDirecotor_Dto direcotor_Dto);
        void AddDirectorwithnationality(GetAllDirecotor_Dto direcotor_Dto);
        void UpdateDirector(int id,AddDirecotor_Dto direcotor_Dto);
        void UpdateDirectorwithnatonality(int id,GetAllDirecotor_Dto direcotor_Dto);
        void DeleteDirector(int id);
    }
}
