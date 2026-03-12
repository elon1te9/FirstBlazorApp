using Microsoft.AspNetCore.Mvc;

namespace Practice1BlazorAPI.Interfaces
{
    public interface IGenreService
    {
        Task<IActionResult> GetGenresAsync();
    }
}
