using Movies.EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Movies.EFDataAccess
{
    public class MoviesContext:DbContext
    {
        public MoviesContext(DbContextOptions options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}
