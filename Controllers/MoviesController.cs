using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Helpers;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MoviesController : Controller
    {
        private readonly MovieDatabaseContext _context;

        public MoviesController(MovieDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("{page}")]  
        public async Task<ActionResult<ICollection<Movie>>> GetPopularMovies(int page)
        {
            int itemsOnPage = 60;
            var movies  =await _context.Movies.OrderByDescending(m => m.Popularity).Skip((page - 1) * itemsOnPage)
                .Take(itemsOnPage).ToListAsync();

            return Ok(movies);
        }

        [HttpGet("{amount}")]
        public async Task<ActionResult<ICollection<Movie>>> GetTopMovies(int amount)
        {
            return Ok(await _context.Movies.OrderByDescending(m => m.Popularity).Take(amount).ToListAsync());
        }

        [HttpGet("{movie_id}")]
        public async Task<ActionResult<Movie>> GetMovieDetails(long movie_id)
        {
            var movie = await _context.Movies.Where(m => m.MovieId == movie_id).Include(m => m.MovieAwards).Include(m => m.MovieReviews).FirstOrDefaultAsync();

            if (movie == null) return NotFound();

            //// getting countries
            //await movie.GetCountries(_context);
            //// getting crew
            //await movie.GetCast(_context);
            //// getting cast
            //await movie.GetCrew(_context);
            //// getting companies
            //await movie.GetCompanies(_context);
            //// geting languages
            //await movie.GetLanguages(_context);
            //// getting keywords
            //await movie.GetKeywords(_context);
            //// getting genres
            //await movie.GetGenres(_context);
            await movie.GetAllDependencies(_context);

            return Ok(movie);
        }
    }
}