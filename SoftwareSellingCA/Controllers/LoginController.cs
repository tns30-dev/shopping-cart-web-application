using Microsoft.AspNetCore.Mvc;
using SoftwareSellingCA.Models;
using System.Collections.Generic;

namespace SoftwareSellingCA.Controllers
{
    public class LoginController : Controller
    {
        
        private MyDbContext db;
        public LoginController(MyDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserPasswordValidation(string username, string passHash)
        {
            var users = db.userPasswordHash.ToList();            
            foreach (var user in users)
            {
                if (user.Username == username && user.PasswordHash == passHash)
                {
                    HttpContext.Session.SetString("username", username);
                    HttpContext.Session.SetString("isLoggedIn", "yes");
                    return RedirectToAction("Index", "Browse");
                }
            }
            ViewBag.ErrorMsg = "Username and password are incorrect!";
            return View("Index");
        }

    }
}
