using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Helpers
{
    public static class MovieHelper
    {

        public static async Task<bool> GetCountries(this Movie movie, MovieDatabaseContext _context)
        {
            var productionCountries = await _context.ProductionCountries.Where(pc => pc.MovieId == movie.MovieId).Include(c => c.CountryIsoNavigation).ToListAsync();

            movie.production_countries = new List<Country>();
            productionCountries.ForEach(p => movie.production_countries.Add(p.CountryIsoNavigation));

            return true;
        }  

        public static async Task<bool> GetCompanies(this Movie movie, MovieDatabaseContext _context)
        {
            var companies = await _context.MovieCompanies.Where(companies => companies.MovieId == movie.MovieId).Include(c => c.Company).ToListAsync();

            movie.production_companies = new List<ProductionCompany>();
            companies.ForEach(p => movie.production_companies.Add(p.Company));

            return true;
        }

        public static async Task<bool> GetLanguages(this Movie movie, MovieDatabaseContext _context)
        {
            var language = await _context.MovieLanguages.Where(l => l.MovieId == movie.MovieId).Include(c => c.Iso6391Navigation).ToListAsync();

            movie.spoken_languages = new List<Language>();
            language.ForEach(p => movie.spoken_languages.Add(p.Iso6391Navigation));

            return true;
        }

        public static async Task<bool> GetKeywords(this Movie movie, MovieDatabaseContext _context)
        {
            var keywords = await _context.MovieKeywords.Where(k => k.MovieId == movie.MovieId).Include(c => c.Keyword).ToListAsync();

            movie.keywords = new List<Keyword>();
            keywords.ForEach(p => movie.keywords.Add(p.Keyword));

            return true;
        }

        public static async Task<bool> GetGenres(this Movie movie, MovieDatabaseContext _context)
        {
            var genres = await _context.MovieGenres.Where(g => g.MovieId == movie.MovieId).Include(c => c.Genre).ToListAsync();

            movie.genres = new List<Genre>();
            genres.ForEach(p => movie.genres.Add(p.Genre));

            return true;
        }

        public static async Task<bool> GetCast(this Movie movie, MovieDatabaseContext _context)
        {
            var cast = await _context.MovieCasts.Where(c => c.MovieId == movie.MovieId).Include(c => c.Person).ToListAsync();

            movie.Cast = new List<Cast>();

            foreach (var actor in cast)
            {
                var person = new Cast(actor.Person);
                person.CharacterName = actor.CharacterName;
                movie.Cast.Add(person);
            }
            return true;
        }

        public static async Task<bool> GetCrew(this Movie movie, MovieDatabaseContext _context)
        {
            var crew = await _context.MovieCrews.Where(c => c.MovieId == movie.MovieId).Include(c => c.Person).Include(d => d.Department).ToListAsync();

            movie.Crew = new List<Crew>();

            foreach (var person in crew)
            {
                var crewPerson = new Crew(person.Person);
                crewPerson.Department = person.Department;
                movie.Crew.Add(crewPerson);
            }
            return true;
        }

        public static async Task<bool> GetAllDependencies(this Movie movie, MovieDatabaseContext _context)
        {
            // getting countries
            await movie.GetCountries(_context); 
            // getting crew
            await movie.GetCast(_context);
            // getting cast
            await movie.GetCrew(_context);
            // getting companies
            await movie.GetCompanies(_context);
            // geting languages
            await movie.GetLanguages(_context);
            // getting keywords
            await movie.GetKeywords(_context);
            // getting genres
            await movie.GetGenres(_context);

            return true;
        }
    }
}
