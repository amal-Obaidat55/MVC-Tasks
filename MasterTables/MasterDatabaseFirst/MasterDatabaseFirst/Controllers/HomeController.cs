using MasterDatabaseFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace MasterDatabaseFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskDbContext _context;
        public HomeController(TaskDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var User = _context.Users.ToList();
            var UserSetting = _context.UserSettings.ToList();
            var Notification = _context.Notifications.ToList();
            var JobSeekerProfile = _context.JobSeekerProfiles.ToList();
            var ExpertProfile = _context.ExpertProfiles.ToList();

            var display = new DisplayTables
            {
                users = User,
                seekers = JobSeekerProfile,
                notifications = Notification,
                experts = ExpertProfile,
                settings = UserSetting
            };
            return View(display);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
