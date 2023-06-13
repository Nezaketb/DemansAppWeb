using DemansAppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace DemansAppWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly EntitiesContext db;


        public LoginController(EntitiesContext _db)
        {
            db = _db;

        }
        public IActionResult Index()
        {
            return View();
        }

        //        [HttpPost]
        //        public IActionResult Login(Login user)
        //        {
        //            var users = db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

        //            if (user != null)
        //            {
        //                return Json(new { success = true, message = "Oturum açma başarılı." });
        //            }

        //            return Json(new { success = false, message = "Geçersiz kullanıcı adı veya şifre." });
        //        }
        //    }
        //}

        [HttpPost, AllowAnonymous]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(u => u.UserName == model.UserName).FirstOrDefault();

                if (user != null)
                {
                    // Kullanıcı bulundu, şifre eşleştirmesini yapabilirsiniz
                    string hashedPassword = HashPassword(model.Password);

                    if (user.Password == hashedPassword)
                    {
                        // Şifre doğru, kullanıcı giriş yapabilir
                        // Giriş işlemiyle ilgili diğer işlemleri gerçekleştirin
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return RedirectToAction("Index", "Login");
        }

        //[HttpPost, AllowAnonymous]
        //public IActionResult Login(Login model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userList = db.Users.Select(s => s.UserName).ToList();
        //        var Count = 0;
        //        foreach (var users in userList)
        //        {
        //            if (users == model.UserName)
        //                Count++;
        //        }
        //        if (Count > 0)
        //        {
        //            ModelState.AddModelError("", "Bu KULLANICI ADI SİSTEMDE kayıtlı");
        //            string hashedPassword = HashPassword(model.Password);

        //            if (user.Password == hashedPassword)
        //            {

        //                // Şifre doğru, kullanıcı giriş yapabilir
        //                // Giriş işlemiyle ilgili diğer işlemleri gerçekleştirin
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        // Kullanıcı adı ve şifreyi alın
        //        //string username = model.UserName;
        //        //string password = model.Password;

        //        //// Kullanıcıyı veritabanından bulun
        //        ////var user = db.Users.FirstOrDefault(u => u.UserName == username);

        //        //if (user != null)
        //        //{
        //        //    // Girilen şifreyi hashleyerek veritabanındaki hash ile karşılaştırın
        //        //    string hashedPassword = HashPassword(password);

        //        //    if (user.Password == hashedPassword)
        //        //    {
        //        //        // Şifre doğru, kullanıcı giriş yapabilir
        //        //        // Giriş işlemiyle ilgili diğer işlemleri gerçekleştirin
        //        //        return RedirectToAction("Index", "Home");
        //        //    }
        //        }
        //      return RedirectToAction("Index", "Login");

        //    // Kullanıcı adı veya şifre hatalı
        //    //ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
        //}

        // Model doğrulama başarısız, hata mesajlarıyla birlikte login sayfasını yeniden gösterin
        //return RedirectToAction("Index", "Login");
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string hashedPassword = Convert.ToBase64String(hashBytes);

                return hashedPassword;
            }
        }
    }
    }

