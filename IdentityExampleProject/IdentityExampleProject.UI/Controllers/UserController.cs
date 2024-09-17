using IdentityExampleProject.UI.Models.Authentication;
using IdentityExampleProject.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityExampleProject.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Country = "Istanbul"
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, model.Sifre);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");   
                }
            }
            return View();
        }
    }
}
