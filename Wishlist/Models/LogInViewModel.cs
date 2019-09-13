using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models
{
    public sealed class LogInViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [Display(Name = "Příště nezobrazovat?")]
        public bool RememberMe { get; set; }
    }
}
