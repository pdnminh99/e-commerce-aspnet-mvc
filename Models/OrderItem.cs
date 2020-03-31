using System;

namespace EcommerceApp2259.Models
{
    public class OrderItem : Product
    {
        public DateTime OrderDate { get; }
        public int Quantity { get; set; }
        public int TotalPrice => Price * Quantity;
    }
}