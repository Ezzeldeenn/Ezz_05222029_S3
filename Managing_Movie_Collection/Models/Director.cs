using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managing_Movie_Collection.Models
{
    public class Director
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }

        public int?NatinalityId { get; set; }
        [ForeignKey(nameof(NatinalityId))]
        public Nationality ?Nationality { get; set; }
        public List<Movie> ?Movies { get; set; }

    }
}
