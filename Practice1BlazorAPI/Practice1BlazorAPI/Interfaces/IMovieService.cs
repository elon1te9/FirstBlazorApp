using Microsoft.AspNetCore.Mvc;
using Practice1BlazorAPI.Requests;

namespace Practice1BlazorAPI.Interfaces
{
    public interface IMovieService
    {
        Task<IActionResult> GetMoviesAsync();
        Task<IActionResult> GetMovieByIdAsync(int id);
        Task<IActionResult> CreateMovieAsync(CreateMovieModel model);
        Task<IActionResult> UpdateMovieAsync(int id, UpdateMovie model);
        Task<IActionResult> DeleteMovieAsync(int id);
    }
}
