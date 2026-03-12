using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice1BlazorAPI.Data;
using Practice1BlazorAPI.Interfaces;

namespace Practice1BlazorAPI.Services
{
    public class GenreService : IGenreService
    {
        private readonly AppDbContext _context;

        public GenreService(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<IActionResult> GetGenresAsync()
        {
            var genres = await _context.Genres.OrderBy(x => x.id_genre).ToListAsync();
            return new OkObjectResult(new
            {
                status = true,
                genres
            });
        }

    }
}
