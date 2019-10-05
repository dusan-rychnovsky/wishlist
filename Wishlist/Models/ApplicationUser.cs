using Newtonsoft.Json;
using System.Security.Claims;

namespace Wishlist.Models
{
    public sealed class ApplicationUser
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "password_hash")]
        public string PasswordHash { get; set; }

        [JsonProperty(PropertyName = "claims")]
        public Claim[] Claims { get; set; }

        public sealed class Claim
        {
            [JsonProperty(PropertyName = "key")]
            public string Key { get; set; }

            [JsonProperty(PropertyName = "value")]
            public string Value { get; set; }
        }
    }
}
