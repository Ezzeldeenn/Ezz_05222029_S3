using Managing_Movie_Collection.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Managing_Movie_Collection.DTOs;

namespace Managing_Movie_Collection.Models
{
    public class GetAllMovie_Dto
    {
        [Required]
        public string Title { get; set; }

        public DateTime ReleseYear { get; set; }

        public List<GetAllDirecotor_Dto> Direcotor_Dtos { get; set; }

        public GetAllCategory_Dto Category_Dto { get; set; }
        public GetAllCinemaDto CinemaDto { get; set; }
    }
    public class Getdataforcinema
    {
        [Required]
        public string Title { get; set; }
        public DateTime ReleseYear { get; set; }
        public List<GetAllDirecotor_Dto> Direcotor_Dtos { get; set; }
        public GetAllCategory_Dto Category_Dto { get; set; }
    }
    public class AllMovie_Dto
    {
        [Required]
        public string Title { get; set; }

        public DateTime ReleseYear { get; set; }
    }
}
