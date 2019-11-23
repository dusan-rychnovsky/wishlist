using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models
{
    public sealed class WishViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Sub Title")]
        public string SubTitle { get; set; }

        public string Description { get; set; }

        public Link[] Links { get; set; } = new Link[0];

        [Required]
        public string Price { get; set; }

        public string ThumbnailImageFilename => this.Id + ".jpg";

        [Required]
        [Display(Name = "Thumbnail Image")]
        public IFormFile ThumbnailImage { get; set; }

        public string ImageFilename => this.Id + "-orig.jpg";

        [Required]
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }

        public sealed class Link
        {
            public string Text { get; set; }

            public string Url { get; set; }
        }
    }
}
