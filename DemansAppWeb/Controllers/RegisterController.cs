using DemansAppWeb.Helper.DTO.Users;
using DemansAppWeb.Models;
using DemansAppWeb.Models.Map;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace DemansAppWeb.Controllers
{
    public class RegisterController : Controller
    {
        private readonly EntitiesContext db;


        public RegisterController(EntitiesContext _db)
        {
            db = _db;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index", "Login");
            }

            return BadRequest();
        }

        private string HashPassword(string password)
        {
            // Şifreyi hashlemek için istediğiniz bir algoritmayı kullanabilirsiniz
            // Örneğin, SHA256 kullanarak:
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}

