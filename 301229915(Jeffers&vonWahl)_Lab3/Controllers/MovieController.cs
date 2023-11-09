using System.Collections.Generic;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HuluWeb.Models;
using Amazon.S3.Transfer;
using Amazon.S3;

namespace HuluWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IDynamoDBContext _context;

        public MovieController(IAmazonDynamoDB dynamoDBClient)
        {
            _context = new DynamoDBContext(dynamoDBClient);
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _context.ScanAsync<Movie>(new List<ScanCondition>()).GetRemainingAsync();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie obj, IFormFile ImageFile)
        {
            
			if (ImageFile != null && ImageFile.Length > 0)
			{
				var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);

				using (var client = new AmazonS3Client(YourAWSCredentials, YourS3Config))
				using (var transferUtility = new TransferUtility(client))
				{
					await transferUtility.UploadAsync(ImageFile.OpenReadStream(), YourBucketName, fileName);
				}
				obj.imageUrl = $"https://{YourBucketName}.s3.amazonaws.com/{fileName}";
			}

			obj.id = System.Guid.NewGuid().ToString();
            obj.uploaderId = 1; // TEMPORARY - Add uploaderId retrieval

            await _context.SaveAsync(obj);
            TempData["success"] = "Movie created successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var movieFromDb = await _context.LoadAsync<Movie>(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }

            return View(movieFromDb);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Movie obj)
        {
            await _context.SaveAsync(obj);
            TempData["success"] = "Movie updated successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var movieFromDb = await _context.LoadAsync<Movie>(id);
            if (movieFromDb == null)
            {
                return NotFound();
            }

            return View(movieFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePOST(string id)
        {
            var obj = await _context.LoadAsync<Movie>(id);
            if (obj == null)
            {
                return NotFound();
            }

            await _context.DeleteAsync(obj);
            TempData["success"] = "Movie deleted successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var movie = await _context.LoadAsync<Movie>(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View("Details", movie);
        }
    }
}
