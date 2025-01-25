using Microsoft.AspNetCore.Mvc;
using SoftwareSellingCA.Models;
using System.Diagnostics;

namespace SoftwareSellingCA.Controllers
{
    public class HomeController : Controller
    {


        private MyDbContext db;

        public HomeController(MyDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
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
