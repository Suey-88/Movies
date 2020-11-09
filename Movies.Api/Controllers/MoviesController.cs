using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Api.Dto;
using Movies.BusinessLogic.ServicesInterface;

namespace Movie.Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        #region Inject

        private readonly ILogger<MovieDto> _logger;
        private readonly IMoviesService _movieService;

        public MoviesController(ILogger<MovieDto> logger, IMoviesService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        #endregion

        #region Movies 
        //Add Movies Controlloers Here

        [AllowAnonymous]
        [HttpGet("getMovie")]
        public async Task<IActionResult> GetMovie(int Id)
        {
            _ = new ObjectResult(false);

            try
            {
                var Movie = await _movieService.GetMovieByID(Id);

                if (Movie == null)
                {
                    return NotFound(new { message = "Movie not found" });
                }
                else
                {

                    return new OkObjectResult(Movie);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return NotFound(new { message = "An error occured" });
            }
        }

        [AllowAnonymous]
        [HttpGet("getAllMovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            _ = new ObjectResult(false);

            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Movies = await _movieService.GetAllMovies();

                if (Movies == null)
                {
                    return NotFound(new { message = "Movies not found" });
                }
                else
                {
                    return new OkObjectResult(Movies);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return NotFound(new { message = "An error occured" });
            }

        }



        [HttpPost]
        [Route("addMovie")]
        public async Task<IActionResult> AddMovie([FromBody()] MovieDto item)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    await _movieService.AddMovie(item);

                    return Ok(new { message = "Movie is added successfully." });
                }

            }

            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return NotFound(new { message = "An error occured" });
            }

        }

        [AllowAnonymous]
        [HttpPut("updateMovie")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody()] MovieDto item)
        {
            try
            {
                if (!ModelState.IsValid || item == null || id == 0)
                {
                    return BadRequest(ModelState);
                }

                else
                {
                    var movie = await _movieService.GetMovieByID(id);
                    if (movie == null)
                    {
                        return NotFound(new { message = "Movie not found" });
                    }

                    await _movieService.UpdateMovie(item);

                    return Ok(new { message = "Movie is updated successfully." });

                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return NotFound(new { message = "An error occured" });
            }

        }

        [AllowAnonymous]
        [HttpDelete("deleteMovie")]
        public async Task<IActionResult> DeleteMovie(int Id)
        {
            try
            {
                var Movie = await _movieService.GetMovieByID(Id);

                if (Movie == null)
                {
                    return NotFound(new { message = "Movies not found" });
                }
                else
                {
                    await _movieService.DeleteMovie(Movie.Id);

                    return Ok(new { message = "Movie is deleted successfully." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return NotFound(new { message = "An error occured" });
            }
        }


        #endregion
    }
}
