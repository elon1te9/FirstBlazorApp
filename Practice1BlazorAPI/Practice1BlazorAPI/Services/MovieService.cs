using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice1BlazorAPI.Data;
using Practice1BlazorAPI.Interfaces;
using Practice1BlazorAPI.Models;
using Practice1BlazorAPI.Requests;

namespace Practice1BlazorAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetMoviesAsync()
        {
            var movies = await _context.Movies
                .OrderBy(x => x.id_movie)
                .Include(x => x.genre)
                .Select(x => new
                {
                    id_movie = x.id_movie,
                    title = x.title,
                    description = x.description,
                    id_genre = x.id_genre,
                    name_genre = x.genre.name,
                    release_date = x.release_date,
                    rating = x.rating,
                    image_url = x.image_url
                })
                .ToListAsync();

            return new OkObjectResult(new
            {
                status = true,
                movies
            });
        }

        public async Task<IActionResult> GetMovieByIdAsync(int id)
        {
            var movie = await _context.Movies
                .Include(x => x.genre)
                .FirstOrDefaultAsync(x => x.id_movie == id);

            if (movie == null)
                return new NotFoundObjectResult(new { error = "Фильм не найден" });

            return new OkObjectResult(new
            {
                status = true,
                movie = new
                {
                    id_movie = movie.id_movie,
                    title = movie.title,
                    description = movie.description,
                    id_genre = movie.id_genre,
                    name_genre = movie.genre.name,
                    release_date = movie.release_date,
                    rating = movie.rating,
                    image_url = movie.image_url
                }
            });
        }

        public async Task<IActionResult> CreateMovieAsync(CreateMovieModel model)
        {
            if (string.IsNullOrWhiteSpace(model.title))
                return new BadRequestObjectResult(new { error = "Название фильма обязательно" });

            if (string.IsNullOrWhiteSpace(model.description))
                return new BadRequestObjectResult(new { error = "Описание фильма обязательно" });

            if (model.rating < 0 || model.rating > 10)
                return new BadRequestObjectResult(new { error = "Рейтинг должен быть от 0 до 10" });

            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.id_genre == model.id_genre);
            if (genre == null)
                return new BadRequestObjectResult(new { error = "Такого жанра нет" });

            var movie = new Movie
            {
                title = model.title,
                description = model.description,
                id_genre = genre.id_genre,
                release_date = model.release_date,
                rating = model.rating,
                image_url = model.image_url
            };

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }

        public async Task<IActionResult> UpdateMovieAsync(int id, UpdateMovie model)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.id_movie == id);

            if (movie == null)
                return new NotFoundObjectResult(new { error = "Фильм не найден" });

            if (string.IsNullOrWhiteSpace(model.title))
                return new BadRequestObjectResult(new { error = "Название фильма обязательно" });

            if (string.IsNullOrWhiteSpace(model.description))
                return new BadRequestObjectResult(new { error = "Описание фильма обязательно" });

            if (model.rating < 0 || model.rating > 10)
                return new BadRequestObjectResult(new { error = "Рейтинг должен быть от 0 до 10" });

            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.id_genre == model.id_genre);
            if (genre == null)
                return new BadRequestObjectResult(new { error = "Такого жанра нет" });

            movie.title = model.title;
            movie.description = model.description;
            movie.id_genre = genre.id_genre;
            movie.release_date = model.release_date;
            movie.rating = model.rating;
            movie.image_url = model.image_url;

            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }

        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.id_movie == id);

            if (movie == null)
                return new NotFoundObjectResult(new { error = "Фильм не найден" });

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new
            {
                status = true
            });
        }
    }
}