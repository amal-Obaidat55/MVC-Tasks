using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task6p2.Models;

namespace Task6p2.Controllers
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
            var category = _context.Categories.Include(x => x.Products).ToList();

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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var delete = _context.Categories.Find(id);

            _context.Categories.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var find = _context.Categories.Find(id);
            return View(find);
        }
    }
}
