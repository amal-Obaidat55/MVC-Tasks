using Microsoft.AspNetCore.Mvc;
using Task6.Models;

namespace Task6.Controllers
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
            var supply = _context.Suppliers.ToList();
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
    }
}
