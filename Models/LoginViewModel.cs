
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp2259.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public override string ToString()
        {
            return $"Phone Number: {Email}, Password: {Password}.\n";
        }
    }

}