using _301229915_Jeffers_vonWahl__Lab3.Models;
using HuluWeb.Data;
using HuluWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace HuluWeb.Controllers
{
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly ILogger<UserController> _logger;
		private object userDb;
		private object Users;

		public UserController(ILogger<UserController> logger, ApplicationDbContext userDb)
		{
			this.userDb = userDb;
			Users = userDb.Users;
			_logger = logger;
		}
		public IActionResult Index()
		{
			return View(model: (IEnumerable<User>)userDb);
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
