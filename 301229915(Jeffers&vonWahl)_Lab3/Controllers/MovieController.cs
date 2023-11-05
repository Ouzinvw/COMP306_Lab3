using HuluWeb.Data;
using HuluWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HuluWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _db;
        public MovieController(MovieDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Movie> movies = _db.Movies.ToList();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

		[HttpPost]
        public IActionResult Create(Movie obj)
		{
            obj.uploaderId = 1; // TEMPORARY - Add uploaderId retrieval
            _db.Movies.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Movie created successfully!";
			return RedirectToAction("Index");
		}

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Movie movieFromDb = _db.Movies.Find(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }
            return View(movieFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Movie obj)
        {
            _db.Movies.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Movie updated successfully!";
            return RedirectToAction("Index");
        }

		public IActionResult Delete(int? id) 
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Movie movieFromDb = _db.Movies.Find(id);
			if (movieFromDb == null)
			{
				return NotFound();
			}
			return View(movieFromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
            Movie? obj = _db.Movies.Find(id); if (obj == null)
            {
                return NotFound();
            }
			_db.Movies.Remove(obj);
			_db.SaveChanges();
            TempData["success"] = "Movie deleted successfully!";
            return RedirectToAction("Index");
		}
	}
}
