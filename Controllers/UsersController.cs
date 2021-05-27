using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly MovieDatabaseContext _context;

        public UsersController(MovieDatabaseContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<ActionResult<User>> Index()
        {
           // User user = new User(0, "AndrzejKrzakowski", "zaq1@WSX", "Andrzej", "Krzakowski", "krzakowskiandrzej@123.pl", true, DateTime.Now, 0, 1, DateTime.Now);
            var movieDatabaseContext = _context.Users.Include(u => u.UserRole);
            return View(await movieDatabaseContext.ToListAsync());
          //  return  (user);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.UserRole)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                user.RegisterTime = DateTime.UtcNow;
                user.LastLogonTime = DateTime.Now;
                _context.Add(user);
                await _context.SaveChangesAsync();
                return StatusCode(201);
            }
            ViewData["UserRoleId"] = new SelectList(_context.UserRoles, "UserRoleId", "RoleName", user.UserRoleId);
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Login()
        {
            var bodyContent = "";

            using (StreamReader reader
                      = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyContent = await reader.ReadToEndAsync();
            }

            // format like username:password
            var username = bodyContent.Split(":")[0];
            var password = bodyContent.Split(":")[1];

            if (ModelState.IsValid)
            {
                var fUser = await _context.Users.Where(u => u.Username == username && u.Password == password)
                    .Include(u => u.MovieReviews).Include(u => u.VoteReviews).FirstOrDefaultAsync();
                if (fUser is null) return NotFound();
                return Ok(fUser);
            }
            return StatusCode(400);
        }
    }
}
