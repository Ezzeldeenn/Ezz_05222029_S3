using Managing_Movie_Collection.DTOs;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace Managing_Movie_Collection.Repo.Natinality
{
    public class NatonalityRepo:INatonalityRepo
    {
        private readonly AppDbContext _Context;
        public NatonalityRepo(AppDbContext context)
        {
            _Context = context;
        }

        public void AddNathonality(GetAllNationality_Dto nationality_Dto)
        {
            var Nathonal = new Models.Nationality
            {
                Name = nationality_Dto.Name,
            };
            _Context.Nationalities.Add(Nathonal);
            _Context.SaveChanges();
        }
        public void DeleteNathonality(int id)
        { 
            var nathonal= _Context.Nationalities.Include(x=>x.Director).FirstOrDefault(x=>x.Id==id);
            if (nathonal == null)
                throw new Exception($"There is no Nathonality with this id:{id}");
            _Context.Nationalities.Remove(nathonal);
            _Context.SaveChanges();
        }
    }
}
