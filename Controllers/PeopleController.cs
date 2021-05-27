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
    public class PeopleController : Controller
    {
        private readonly MovieDatabaseContext _context;

        public PeopleController(MovieDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("{page}")]
        public async Task<ActionResult<ICollection<Person>>> GetPopularPeople(int page)
        {
            int itemsOnPage = 60;
            var movies = await _context.People.OrderByDescending(m => m.PersonName).Skip((page - 1) * itemsOnPage)
                .Take(itemsOnPage).ToListAsync();

            return Ok(movies);
        }

        [HttpGet("{person_id}")]
        public async Task<ActionResult<Person>> GetPersonDetails(long person_id)
        {
            var person = await _context.People.Where(m => m.PersonId == person_id).FirstOrDefaultAsync();

            if (person == null) return NotFound();

            await person.GetAllDependencies(_context);

            return Ok(person);
        }
    }
}
