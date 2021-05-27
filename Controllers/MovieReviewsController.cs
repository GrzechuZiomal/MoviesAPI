using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MovieReviewsController : Controller
    {
        private readonly MovieDatabaseContext _context;

        public MovieReviewsController(MovieDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<MovieReview> Details()
        {
            var movie = new MovieReview()
            {
                ReviewRating = 5.5M,
                ReviewDescription = "elo elo dobry film",
                UserId = 2,
                MovieId = 178,
                ReviewDatetime = DateTime.UtcNow,
                UserScore = 80.5M,
                Movie = null,
                ReviewId = 1,
                User = null,
                VoteReviews = null
            };

            return movie;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieReview);
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }

            return StatusCode(401);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movieReview = await _context.MovieReviews.FindAsync(id);
            _context.MovieReviews.Remove(movieReview);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool MovieReviewExists(int id)
        {
            return _context.MovieReviews.Any(e => e.ReviewId == id);
        }
    }
}
