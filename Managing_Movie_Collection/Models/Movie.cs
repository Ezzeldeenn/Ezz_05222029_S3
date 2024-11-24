using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Managing_Movie_Collection.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime ReleseYear { get; set; }

        public List<Director> Directors { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int CienemaId { get; set; }
        [ForeignKey(nameof(CienemaId))]
        public Cinema Cinema { get; set; }
    }
}
