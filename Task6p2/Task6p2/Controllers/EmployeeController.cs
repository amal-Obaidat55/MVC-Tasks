using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task6p2.Models;

namespace Task6p2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly TaskDbContext _context;
        public EmployeeController(TaskDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employee = _context.Employees.Include(x=>x.Order1s).ToList();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var delete = _context.Employees.Find(id);

            _context.Employees.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var find = _context.Employees.Find(id);
            return View(find);
        }
    }
}
