using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Api.Dto;
using System;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        #region Inject

        private readonly ILogger<CartDto> _logger;

        public CartController(ILogger<CartDto> logger)
        {
            _logger = logger;
        }

        #endregion
        [AllowAnonymous]
        [HttpGet("getCart")]
        public IActionResult GetCart(int Id)
        {
            _ = new ObjectResult(false);

            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);

                return NotFound(new { message = "An error occured" });
            }
        }

    }
}
