using Microsoft.AspNetCore.Mvc;
using Practice1BlazorAPI.Interfaces;
using Practice1BlazorAPI.Requests;

namespace Practice1BlazorAPI.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        public readonly IMovieService _movieService;
        public MovieController(IMovieService movieService) 
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesAsync()
        {
            return await _movieService.GetMoviesAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieByIdAsync(int id)
        {
            return await _movieService.GetMovieByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync([FromBody] CreateMovieModel model)
        {
            return await _movieService.CreateMovieAsync(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(int id, [FromBody] UpdateMovie model)
        {
            return await _movieService.UpdateMovieAsync(id, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            return await _movieService.DeleteMovieAsync(id);
        }
    }
}
