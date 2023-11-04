using _301229915_Jeffers_vonWahl__Lab3.Models;
using HuluWeb.Data;
using HuluWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _301229915_Jeffers_vonWahl__Lab3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _userDb;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext userDb)
        {
            _userDb = userDb;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<User> users = _userDb.Users;
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}