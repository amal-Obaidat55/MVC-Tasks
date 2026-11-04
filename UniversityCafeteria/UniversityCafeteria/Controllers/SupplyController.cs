using Microsoft.AspNetCore.Mvc;

namespace UniversityCafeteria.Controllers
{
    public class SupplyController : Controller
    {
        public IActionResult Index()
        {
            List<string> categories = new List<string>() {"Drinks" , "Food" , "Snacks" , "Hot Drinks" , "Cold Drinks" };
            ViewBag.Categories = categories;
            return View();
        }
        public IActionResult Products()
        {
            ViewData["Title"] = "Cafeteria Products";
            ViewData["managerName"] = "Ahmad Ali";
            ViewData["numOfProduct"] = 5;

            string[] products = { "Water", "Orange Juice", "Coffee", "Sandwich", "Chocolate" };
            ViewData["Products"]= products;
            return View();
        }
        public IActionResult Suppliers()
        {
            ViewBag.Title = "Our Suppliers";
            ViewBag.Total = 3;

            string[] suppliers = { "Fresh Food Company", "Happy Drinks Company", "Daily Supplies Company", "Best Market Company" };
            ViewBag.Suppliers = suppliers;
            return View();
        }
        [HttpGet]
        public IActionResult CreateRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitRequest()
        {
            string EName = Request.Form["employeeName"];
            string PName = Request.Form["productName"];
            string quantity = Request.Form["Quantity"];
            string Date = Request.Form["Date"];


            
            TempData["message"] = "";
            if(EName == "")
            {
                TempData["message"] = "Try Again, Enter Employee Name";
            }
            else
            {
                TempData["message"] = "Submit Successfuly";
                TempData["EName"] = EName;
                return RedirectToAction("About");
            }
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult QuantityTest(int quantity)
        {
            if (quantity < 20)
            {
                ViewBag.Message = "Small Order";
            }
            else if (quantity >= 20 && quantity <= 50)
            {
                ViewBag.Message = "Medium Order";
            }
            else if (quantity > 50)
            {
                ViewBag.Message = "Large Order";
            }

            ViewBag.Quantity = quantity;

            return View();
        }

    }
}
