using Microsoft.AspNetCore.Mvc;
using Task6.Models;

namespace Task6.Controllers
{
    public class CategoryController : Controller
    {
        private readonly TaskDbContext _context;
        public CategoryController(TaskDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var category = _context.Categories.ToList();

            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
