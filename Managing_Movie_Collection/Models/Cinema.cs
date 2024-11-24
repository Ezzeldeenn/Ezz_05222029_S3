using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Managing_Movie_Collection.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Placehorder { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
