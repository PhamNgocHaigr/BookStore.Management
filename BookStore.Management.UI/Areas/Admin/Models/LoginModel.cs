using System.ComponentModel.DataAnnotations;

namespace BookStore.Management.UI.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username must be not empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Username must be not empty")]
        [MinLength(3, ErrorMessage ="Password must be greater than 3 characters")]
        public string Password { get; set; }
        public bool HasRememberMe { get; set; }
    }
}
