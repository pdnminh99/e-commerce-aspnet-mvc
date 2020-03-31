using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp2259.Models
{

    [Table("User")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Display(Name = "Full name")]
        public string Name { get; set; }

        [ForeignKey("UserType")]
        public UserType Type { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }

}