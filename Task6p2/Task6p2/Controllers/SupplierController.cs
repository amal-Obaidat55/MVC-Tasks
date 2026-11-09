using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task6p2.Models;

namespace Task6p2.Controllers
{
    public class SupplierController : Controller
    {
        private readonly TaskDbContext _context;
        public SupplierController(TaskDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var supply = _context.Suppliers.Include(x=>x.Products).ToList();
            return View(supply);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            return View(supplier);
        }
        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var delete = _context.Suppliers.Find(id);

            _context.Suppliers.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var find = _context.Suppliers.Find(id);
            return View(find);
        }
    }
}
