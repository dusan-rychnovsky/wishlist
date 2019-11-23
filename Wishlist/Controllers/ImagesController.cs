using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;
using Wishlist.Models;

namespace Wishlist.Controllers
{
    [Authorize]
    public sealed class ImagesController : Controller
    {
        private readonly IImageService imageService;

        public ImagesController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public async Task<FileStreamResult> Get(string id)
        {
            var stream = await this.imageService.GetImageAsync(id);
            return new FileStreamResult(stream, MediaTypeNames.Image.Jpeg);
        }
    }
}
