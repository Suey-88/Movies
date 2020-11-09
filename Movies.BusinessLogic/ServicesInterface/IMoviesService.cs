using Movies.BusinessLogic.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.EFDataAccess.Models;
using Movies.Api.Dto;

namespace Movies.BusinessLogic.ServicesInterface
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<List<MovieDto>> GetAllMovies();
        Task<MovieDto> GetMovieByID(int ID);
        Task<int> CountMovies();
        Task AddMovie(MovieDto Movies);
        Task UpdateMovie(MovieDto Movies);
        Task DeleteMovie(int Id);
    }
}
