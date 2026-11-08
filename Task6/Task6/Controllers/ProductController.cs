using Microsoft.AspNetCore.Mvc;
using Task6.Models;

namespace Task6.Controllers
{
    public class ProductController : Controller
    {
        private readonly TaskDbContext _context;
        public ProductController(TaskDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
