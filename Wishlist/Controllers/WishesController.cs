using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Models;

namespace Wishlist.Controllers
{
    [Authorize]
    public sealed class WishesController : Controller
    {
        private readonly IWishService wishService;

        public WishesController(IWishService wishService)
        {
            this.wishService = wishService;
        }

        public async Task<IActionResult> Index()
        {
            var wishes = await this.wishService.GetAllWishesAsync();
            var viewModels = wishes.Select(this.ToViewModel).ToArray();
            return View(viewModels);
        }

        private WishViewModel ToViewModel(Wish wish)
        {
            return new WishViewModel
            {
                Id = wish.Id,
                Title = wish.Title,
                SubTitle = wish.SubTitle,
                Description = wish.Description,
                Links = wish.Links.Select(link => new WishViewModel.Link
                {
                    Text = link.Text,
                    Url = link.Url
                }).ToArray(),
                Price = wish.Price
            };
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(WishViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            RemoveEmptyLinks(model);

            await this.wishService.CreateWishAsync(this.ToWish(model));

            return this.RedirectToAction("Index");
        }

        private static void RemoveEmptyLinks(WishViewModel model)
        {
            model.Links = model.Links
                .Where(link => !string.IsNullOrEmpty(link.Url))
                .ToArray();
        }

        private Wish ToWish(WishViewModel model)
        {
            return new Wish
            {
                Id = model.Id,
                Title = model.Title,
                SubTitle = model.SubTitle,
                Description = model.Description,
                Links = model.Links.Select(link => new Wish.Link
                {
                    Text = link.Text,
                    Url = link.Url
                }).ToArray(),
                Price = model.Price
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
