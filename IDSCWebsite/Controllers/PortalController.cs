using Microsoft.AspNetCore.Mvc;

namespace IDSCWebsite.Controllers
{
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StudentLogin()
        {
            return View();
        }
        public IActionResult InstructorLogin()
        {
            return View();
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
    }
}
