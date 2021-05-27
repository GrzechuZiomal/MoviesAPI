using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Helpers
{
    public static class PersonHelper
    {
        public static async Task<bool> GetJobs(this Person person, MovieDatabaseContext _context)
        {
            var moviecrew = await _context.MovieCrews.Where(mc => mc.PersonId == person.PersonId)
                .Include(mc => mc.Department).Include(mc => mc.Movie).ToListAsync();

            person.WorkedIn = moviecrew;

            return true;
        }

        public static async Task<bool> GetEngagement(this Person person, MovieDatabaseContext _context)
        {
            var moviecast = await _context.MovieCasts.Where(mc => mc.PersonId == person.PersonId)
                .Include(mc => mc.Movie).ToListAsync();

            person.PlayedIn = moviecast;

            return true;
        }

        public static async Task<bool> GetAllDependencies(this Person person, MovieDatabaseContext _context)
        {
            await person.GetEngagement(_context);
            await person.GetJobs(_context);

            return true;
        }
    }
}
