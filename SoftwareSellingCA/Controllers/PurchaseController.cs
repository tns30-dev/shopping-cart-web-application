using Microsoft.AspNetCore.Mvc;
using SoftwareSellingCA.Models;

namespace SoftwareSellingCA.Controllers
{
    public class PurchaseController : Controller
    {
        private MyDbContext db;

        public PurchaseController(MyDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("username");

            // Fetch the customer details for the logged-in user
            CustomerDetails customerObj = db.customerDetailsData.FirstOrDefault(x => x.customername == username);

            if (customerObj == null)
            {
                // Handle the case where the customer details are not found
                return RedirectToAction("Index", "Login");
            }

            string customerid = customerObj.customerid;

            // Fetch activation codes for the logged-in customer only
            var activationCodes = db.activationCodes.Where(ac => ac.CustomerDetailsId == customerid).ToList();

            PurchaseFinal purchaseFinal = new PurchaseFinal()
            {
                ActivationCodeProducts = activationCodes
            };

            return View(purchaseFinal);
        }


        public IActionResult CheckOut()
        {
            // check if user is logged in
            string? loggedin = HttpContext.Session.GetString("isLoggedIn");
            if (loggedin == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // Retrieve chosen product IDs from Session
            string chosenProductListNames = HttpContext.Session.GetString("chosenProductList");
            List<string> chosenProductIds = chosenProductListNames?.Split(',')?.ToList() ?? new List<string>();

            if(chosenProductListNames == "")
            {
                ViewData["newCheckOutItems"] = 0;
                return View("Checkout");
            }

            ViewData["newCheckOutItems"] = chosenProductIds.Count;

            Dictionary<string, int> chosenProductTime = new Dictionary<string, int>();

            //now we know which products are selected and how many times they have been chosen
            foreach (string chosenProductId in chosenProductIds)
            {
                if (!chosenProductTime.ContainsKey(chosenProductId))
                {
                    chosenProductTime.Add(chosenProductId, 1);
                }
                else
                {
                    chosenProductTime[chosenProductId]++;
                }
            }

            List<ProductClick> productClicks = new List<ProductClick>();

            foreach (var kvp in chosenProductTime)
            {
                Product product = db.productsData.FirstOrDefault(x => x.ProductId == kvp.Key);
                int click = kvp.Value;
                productClicks.Add(new ProductClick()
                {
                    Product = product,
                    Click = click
                });
            }

            foreach (var productClick in productClicks)
            {
                //getting the customer id from the username (session)
                string username = HttpContext.Session.GetString("username");
               
                CustomerDetails customerObj = db.customerDetailsData.FirstOrDefault(x => x.customername == username);
                string customerid = customerObj.customerid;

                Product product = db.productsData.FirstOrDefault(x => x.ProductId == productClick.Product.ProductId);
                CustomerDetails customerDetails = db.customerDetailsData.FirstOrDefault(x => x.customerid == customerid);

                int numberOfOrder = productClick.Click;

                for (int i = 0; i < numberOfOrder; i++)
                {
                    if (product != null && customerDetails != null)
                    {
                        db.activationCodes.Add(new ActivationCodeProductCustomer()
                        {
                            ProductId = product.ProductId,
                            CustomerDetailsId = customerDetails.customerid
                        });
                    }
                }

                
            }

            db.SaveChanges();


            HttpContext.Session.SetString("chosenProductList", "");

            return View();
        }
    }
    
}
