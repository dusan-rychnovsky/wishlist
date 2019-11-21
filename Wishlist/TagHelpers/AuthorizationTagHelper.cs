using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Wishlist.Views
{
    [HtmlTargetElement(Attributes = "asp-claim")]
    public sealed class AuthorizationTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthorizationTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("asp-claim")]
        public string Claim { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!this.httpContextAccessor.HttpContext.User.HasClaim(this.Claim, "true"))
            {
                output.SuppressOutput();
            }
        }
    }
}
