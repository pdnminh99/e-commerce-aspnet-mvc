// using System;

// namespace EcommerceApp2259.Models
// {
//     public class OrderItem : Product
//     {
//         public DateTime OrderDate { get; }
//         public int Quantity { get; set; }
//         public int TotalPrice => Price * Quantity;
//         public OrderItem(string name, int price, DateTime createdDate, string category, string brand, int quantity, DateTime orderDate) : base(name, price, createdDate, category, brand)
//         {
//             OrderDate = orderDate;
//             Quantity = quantity;
//         }
//     }
// }