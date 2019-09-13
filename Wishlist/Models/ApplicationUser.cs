using Newtonsoft.Json;

namespace Wishlist.Models
{
    public sealed class ApplicationUser
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password_hash")]
        public string PasswordHash { get; set; }
    }
}
