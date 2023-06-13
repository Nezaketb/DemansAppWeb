using DemansAppWeb.Helper.DTO.Users;
using DemansAppWeb.Models;
using DemansAppWeb.Models.Map;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(addUserRequest model)
        {

            if (!ModelState.IsValid)
            {
                var userList = db.Users.Select(s => s.UserName).ToList();
                var Count = 0;
                foreach (var user in userList)
                {
                    if(user == model.UserName) 
                    Count++;
                }
                if (Count > 0)
                {
                    ModelState.AddModelError("", "Bu KULLANICI ADI SİSTEMDE kayıtlı");
                }

                else
                        {
                    var user = new Users()
                    {
                        Email = model.Email,
                        UserName = model.UserName,
                        Surname = model.Surname,
                        EmergencyPhone = model.EmergencyPhone,
                        Sex = model.Sex,
                        Password = HashPassword(model.Password)
                    };

                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index", "Login");
                }
            }
                return RedirectToAction("Index", "Register");
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

