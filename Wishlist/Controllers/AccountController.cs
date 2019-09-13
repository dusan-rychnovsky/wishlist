using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wishlist.Models;

namespace Wishlist.Controllers
{
    public sealed class AccountController : Controller
    {
        public const string VIEWER_EMAIL = "VIEWER@EMAIL.CZ";

        private readonly SignInManager<ApplicationUser> signInManager;
        
        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInViewModel model, string returnUrl = null)
        {
            var user = new ApplicationUser { Email = VIEWER_EMAIL };
            
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await this.signInManager.PasswordSignInAsync(VIEWER_EMAIL, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return this.Redirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Neplatné heslo.");
                return View(model);
            }

            return View(model);
        }
    }
}
