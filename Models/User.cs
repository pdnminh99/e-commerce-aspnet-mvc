using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp2259.Models
{
    public class User : IdentityUser
    {
        [Display(Name = "Date of birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "First name")]
        [Required]
        [DataType(DataType.Text)]
        [MinLength(1, ErrorMessage = "Invalid first name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        [DataType(DataType.Text)]
        [MinLength(1, ErrorMessage = "Invalid last name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Address { get; set; }
    }
}