using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wishlist.Models;

namespace Wishlist.Controllers
{
    public sealed class AdminController : Controller
    {
        public const string ADMIN_EMAIL = "ADMIN@EMAIL.CZ";

        private readonly SignInManager<ApplicationUser> signInManager;
        
        public AdminController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInViewModel model, string returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            if (this.ModelState.IsValid)
            {
                var result = await this.signInManager.PasswordSignInAsync(ADMIN_EMAIL, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return this.RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Neplatné heslo.");
                return this.View(model);
            }

            return this.View(model);
        }

        private IActionResult RedirectToLocal(string url)
        {
            if (Url.IsLocalUrl(url))
            {
                return this.Redirect(url);
            }
            else
            {
                return this.Redirect("/");
            }
        }
    }
}
