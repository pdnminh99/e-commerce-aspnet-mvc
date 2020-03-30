using System;

namespace EcommerceApp2259.Models
{
    public class OrderItem : Product
    {
        public DateTime orderDate { get; }
        public int quantity { get; set; }
        public int totalPrice => price * quantity;
        public OrderItem(string name, int price, DateTime createdDate, string category, string brand, int quantity, DateTime orderDate) : base(name, price, createdDate, category, brand)
        {
            this.orderDate = orderDate;
            this.quantity = quantity;
        }
    }
}