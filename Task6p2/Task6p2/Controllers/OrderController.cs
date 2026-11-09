using Microsoft.AspNetCore.Mvc;
using Task6p2.Models;

namespace Task6p2.Controllers
{
    public class OrderController : Controller
    {
        private readonly TaskDbContext _context;
        public OrderController(TaskDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var order = _context.Order1s.ToList();
            return View(order);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var employees = _context.Employees.ToList();
            ViewBag.Employees = employees;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order1 order)
        {
            _context.Order1s.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _context.Order1s.Find(id);
            return View(order);
        }
        [HttpPost]
        public IActionResult Edit(Order1 order)
        {
            _context.Order1s.Update(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var delete = _context.Order1s.Find(id);

            _context.Order1s.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var find = _context.Order1s.Find(id);
            return View(find);
        }
    }
}
