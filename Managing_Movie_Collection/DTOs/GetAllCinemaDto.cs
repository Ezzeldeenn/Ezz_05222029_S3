using Managing_Movie_Collection.Models;

namespace Managing_Movie_Collection.DTOs
{
    public class GetAllCinemaDto
    {
        public string Name { get; set; }
        public int Placehorder { get; set; }
    }
    public class Getcinemarelation
    {
        public string Name { get; set; }
        public int Placehorder { get; set; }
        public List<Getdataforcinema> Dataformovie { get; set; }

    }
}
