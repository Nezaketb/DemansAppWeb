using DemansAppWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemansAppWeb.Controllers
{
    public class PicturesController : Controller
    {
        private readonly EntitiesContext db;

        public PicturesController(EntitiesContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(IFormFile imageFile, string text)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);

                    // Resmi byte dizisine dönüştürün
                    byte[] imageBytes = memoryStream.ToArray();

                    // Veritabanına kaydedin
                    var resim = new Pictures { Url = imageBytes, Text = text };
                    db.Pictures.Add(resim);
                    db.SaveChanges();
                }

                return Ok();
            }

            return BadRequest("Resim yüklenemedi");
        }

        public IActionResult GetImages()
        {
            var images = db.Pictures.ToList();
            return Json(images);
        }
    }
}
