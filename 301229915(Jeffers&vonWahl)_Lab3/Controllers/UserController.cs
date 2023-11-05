using HuluWeb.Data;
using HuluWeb.Models;
using Microsoft.AspNetCore.Mvc;


namespace HuluWeb.Controllers
{
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _db;
		public UserController(ApplicationDbContext db)
		{
			_db = db;
		}
	}
}
