using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp2259.Models
{

    public class User
    {
        public Guid? UUID { get; }
        public string Name { get; set; }
        public UserType Type { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; }

        public User(Guid? UUID, string name, UserType type, string phone, string email, DateTime? createdDate)
        {
            this.UUID = UUID;
            this.CreatedDate = createdDate ?? DateTime.Now;
        }
    }

}