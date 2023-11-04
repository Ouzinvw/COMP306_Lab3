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
			return RedirectToAction("Index");
		}
	}
}
