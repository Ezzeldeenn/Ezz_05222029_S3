using Managing_Movie_Collection.Models;
using System.ComponentModel.DataAnnotations;

namespace Managing_Movie_Collection.DTOs
{
    public class GetAllDirecotor_Dto
    {
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }

        public GetAllNationality_Dto GetAllNationality { get; set; }
    }  
    public class AddDirecotor_Dto
    {
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
    }
}
