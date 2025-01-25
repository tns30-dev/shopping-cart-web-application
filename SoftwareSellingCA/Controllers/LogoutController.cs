using Microsoft.AspNetCore.Mvc;
using SoftwareSellingCA.Models;

namespace SoftwareSellingCA.Controllers
{
    public class LogoutController : Controller
    {
        private MyDbContext db;
        public LogoutController(MyDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
