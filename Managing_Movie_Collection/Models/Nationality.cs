using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managing_Movie_Collection.Models
{
    public class Nationality
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
         
        public Director Director { get; set; }
    }
}
