using System.ComponentModel.DataAnnotations;
using System;

namespace EcommerceApp2259.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First name")]
        [MaxLength(50, ErrorMessage = "First name should not too long.")]
        [MinLength(1, ErrorMessage = "First name must not empty.")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        [MaxLength(50, ErrorMessage = "Last name should not too long.")]
        [MinLength(1, ErrorMessage = "Last name must not empty.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        [MaxLength(11, ErrorMessage = "Phone number must not exceed 11 digits.")]
        [MinLength(10, ErrorMessage = "Phone number must not shorter than 10 digits.")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [MinLength(1, ErrorMessage = "Email must longer than 1 character.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Email: ${Email}, Password: ${Password}";
        }
    }
}