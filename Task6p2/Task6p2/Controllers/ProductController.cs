using Microsoft.AspNetCore.Mvc;
using Task6p2.Models;

namespace Task6p2.Controllers
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
            var supplier = _context.Suppliers.ToList();
            var category = _context.Categories.ToList();

            ViewBag.Supplier = supplier;
            ViewBag.Category = category;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var delete = _context.Products.Find(id);

            _context.Products.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var find = _context.Products.Find(id);
            return View(find);
        }
    }
}
