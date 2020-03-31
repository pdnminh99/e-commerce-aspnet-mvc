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

        [Column("UserType")]
        private string _Type
        {
            set
            {
                Type = value switch
                {
                    "customer" => UserType.CUSTOMER,
                    "admin" => UserType.ADMIN,
                    _ => UserType.UNKNOWN
                };
            }
        }

        [NotMapped]
        public UserType Type { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }

}