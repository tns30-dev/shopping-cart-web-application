using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using SoftwareSellingCA.Models;
using System.Diagnostics;
using System.Linq;

namespace SoftwareSellingCA.Controllers
{
    public class CartController : Controller
    {
        private MyDbContext db;
        public CartController(MyDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public IActionResult UpdateQuantity(string productId, int quantity)
        {
            // Retrieve chosen product IDs from Session
            string chosenProductListNames = HttpContext.Session.GetString("chosenProductList");
           
            List<string> chosenProductIds = chosenProductListNames?.Split(',')?.ToList() ?? new List<string>();

            // Remove the current productId from the list
            chosenProductIds.RemoveAll(id => id == productId);

            // Add the new productId based on the selected quantity
            for (int i = 0; i < quantity; i++)
            {
                chosenProductIds.Add(productId);
            }

            // Update Session with the new list
            HttpContext.Session.SetString("chosenProductList", string.Join(",", chosenProductIds));

            return Json(new { success = true });
        }

        public IActionResult Index()
        {
            //Retrieve chosen product IDs from Session
            string chosenProductListNames = HttpContext.Session.GetString("chosenProductList");
            if (chosenProductListNames == "" || chosenProductListNames == null)
            {
                return View("EmptyCart");
            }
            List<string> chosenProductIds = chosenProductListNames?.Split(',')?.ToList() ?? new List<string>();

            Dictionary<string, int> chosenProductTime = new Dictionary<string, int>();

            //now we know which products are selected and how many times they have been chosen
            foreach(string chosenProductId in chosenProductIds)
            {
                if(!chosenProductTime.ContainsKey(chosenProductId)) 
                { 
                    chosenProductTime.Add(chosenProductId, 1);
                }
                else
                {
                    chosenProductTime[chosenProductId]++;
                }
            }

            List<ProductClick> productClicks = new List<ProductClick>();

            foreach(var kvp in chosenProductTime)
            {
                Product product = db.productsData.FirstOrDefault(x => x.ProductId == kvp.Key);
                int click = kvp.Value;
                productClicks.Add(new ProductClick()
                {
                    Product = product,
                    Click = click
                });
            }

            CartViewModel dummy = new CartViewModel()
            {
                CartedProducts = productClicks
            };

            return View(dummy);
        }

        [HttpGet]
        public IActionResult GetChosenProducts()
        {
            string chosenProductListNames = HttpContext.Session.GetString("chosenProductList");
            if (chosenProductListNames == "")
            {
                return View("EmptyCart");
            }
            List<string> chosenProductIds = chosenProductListNames?.Split(',')?.ToList() ?? new List<string>();

            return Json(chosenProductIds);
        }
    }
}
