using Managing_Movie_Collection.DTOs;
using Managing_Movie_Collection.Models;

namespace Managing_Movie_Collection.Repo.Category
{
    public interface ICategoryRepo
    {
        void Add(GetAllCategory_Dto categoryDto);
        void Update(GetAllCategory_Dto categoryDto, int Id);


    }
}
