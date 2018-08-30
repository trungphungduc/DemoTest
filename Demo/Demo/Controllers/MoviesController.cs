using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Models;
using DataAccess.Services;

namespace Demo.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _context;
        private string UserLogin = "PDTrung";

        public MoviesController(MovieService context)
        {

            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString(Constants.SESSION_KEY_LOGIN_SYSTEM_ADMIN_ID, UserLogin);
            return View(await _context.GetAll());
        }

        /*
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(a => a.Title.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }


        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
*/
        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                if((await _context.IsTitleDuplicate(movie.Title)))
                {
                    TempData["ErrorMessage"] = "Title was duplicated !";
                    return View(movie);
                }
                movie.UserCreated = HttpContext.Session.GetString(Constants.SESSION_KEY_LOGIN_SYSTEM_ADMIN_ID);
                movie.DateCreated = DateTime.Now;

                await _context.Add(movie);

                return RedirectToAction("Index");
            }
            return View(movie);
        }


        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, MovieModel movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    movie.UserUpdated = HttpContext.Session.GetString(Constants.SESSION_KEY_LOGIN_SYSTEM_ADMIN_ID);
                    movie.DateUpdated = DateTime.Now;

                    await _context.Update(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _context.IsExists(movie.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        /*
        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return View(movie);
        }

        */
    }
}
