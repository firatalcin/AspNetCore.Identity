using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExampleProject.UI.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "tor")]
        public IActionResult Page1()
        {
            return View();
        }

        [Authorize(Roles = "Editor")]
        public IActionResult Page2()
        {
            return View();
        }

        [Authorize(Roles = "Moderator")]
        public IActionResult Page3()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Page4()
        {
            return View();
        }
    }
}
