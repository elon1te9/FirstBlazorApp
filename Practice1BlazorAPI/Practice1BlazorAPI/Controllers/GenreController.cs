using Microsoft.AspNetCore.Mvc;
using Practice1BlazorAPI.Interfaces;

namespace Practice1BlazorAPI.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController : Controller
    {
        public readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenresAsync()
        {
            return await _genreService.GetGenresAsync();
        }
    }
}
