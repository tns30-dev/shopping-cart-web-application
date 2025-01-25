using Microsoft.AspNetCore.Mvc;
using SoftwareSellingCA.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SoftwareSellingCA.Controllers
{
    public class BrowseController : Controller
    {
        private MyDbContext db;

        public BrowseController(MyDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string searchTerm)
        {
            List<Product> products;

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Display all products
                products = db.productsData.ToList();
                ViewData["searchFound"] = true;
            }
            else
            {
                // Filter products based on search term
                products = db.productsData
                            .Where(p => p.Description.ToLower().Contains(searchTerm.ToLower())
                                        || p.ProductName.ToLower() == searchTerm.ToLower()
                                        || p.Price.ToString() == searchTerm)
                            .ToList();
                if(products.Count == 0)
                {
                    ViewData["searchFound"] = false;
                }
                else
                {
                    ViewData["searchFound"] = true;
                }
            }

            ProductListM productListM = new ProductListM()
            {
                Products = products
            };

            ViewData["stringInSearch"] = searchTerm;

            // Get the username
            string username = HttpContext.Session.GetString("username");
            ViewData["currentUser"] = username;

            UpdateCartCount();

            // Update ViewData with the latest cart count
            ViewData["currentCount"] = HttpContext.Session.GetInt32("currentCartCount");

            return View(productListM);
        }

        private void UpdateCartCount()
        {
            string chosenProductListNames = HttpContext.Session.GetString("chosenProductList");

            if(chosenProductListNames == "")
            {
                HttpContext.Session.SetInt32("currentCartCount", 0);
            }
            else
            {
                List<string> chosenProductIds = chosenProductListNames?.Split(',')?.ToList() ?? new List<string>();

                int currentCartCount = chosenProductIds.Count;
                HttpContext.Session.SetInt32("currentCartCount", currentCartCount);
            }
        }

        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            return RedirectToAction("Index", new { searchTerm = searchTerm });
        }
        
        public IActionResult ChosenProducts(string ProductId)
        {
            int ? currentCartCount = HttpContext.Session.GetInt32("currentCartCount");
            string chosenProductListNames = HttpContext.Session.GetString("chosenProductList");

            if (string.IsNullOrEmpty(chosenProductListNames))
            {
                chosenProductListNames = "";
            }

            if (!currentCartCount.HasValue || currentCartCount.Value == 0)
            {
                currentCartCount = 0;
            }

            List<Product> allProducts = db.productsData.ToList();
            Product chosenProduct = allProducts.FirstOrDefault(p => p.ProductId == ProductId);

            if (chosenProduct != null)
            {
                if (!string.IsNullOrEmpty(chosenProductListNames))
                {
                    chosenProductListNames += ",";
                }

                chosenProductListNames += chosenProduct.ProductId;

                HttpContext.Session.SetString("chosenProductList", chosenProductListNames);
            }

            List<string> chosenProductIds = chosenProductListNames?.Split(',')?.ToList() ?? new List<string>();

            currentCartCount = chosenProductIds.Count;
            HttpContext.Session.SetInt32("currentCartCount", (int)currentCartCount);

            return Json(new { success = true });
        }

        public IActionResult MyPurchase()
        {
            return RedirectToAction("Index", "Purchase");
        }

        [HttpGet]
        public IActionResult GetCartCount()
        {
            string chosenProductListNames = HttpContext.Session.GetString("chosenProductList");

            List<string> chosenProductIds = chosenProductListNames?.Split(',')?.ToList() ?? new List<string>();

            int? currentCartCount = HttpContext.Session.GetInt32("currentCartCount");

            if (!currentCartCount.HasValue || currentCartCount.Value == 0)
            {
                currentCartCount = 0;
            }

            currentCartCount = chosenProductIds.Count;
            HttpContext.Session.SetInt32("currentCartCount", (int)currentCartCount);
            //int currentCount = HttpContext.Session.GetInt32("currentCartCount") ?? 0;
            return Json(new { count = currentCartCount });
        }
    }
}

    

