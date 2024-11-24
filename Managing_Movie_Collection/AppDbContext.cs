using Managing_Movie_Collection.Models;
using Microsoft.EntityFrameworkCore;

namespace Managing_Movie_Collection
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions option):base (option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }    
        public DbSet<Category> Categories { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Cinema>Cinemas { get; set; }
    }
}
