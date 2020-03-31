using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp2259.Models
{

    public class User
    {
        public Guid? UUID { get; }

        [Display(Name = "Full name")]
        public string Name { get; set; }
        public UserType Type { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; }
        public User(Guid? uuid, string name, UserType type, string phone, string email, DateTime? createdDate)
        {
            UUID = uuid;
            CreatedDate = createdDate ?? DateTime.Now;
        }
    }

}