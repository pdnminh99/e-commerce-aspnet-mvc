// using System;
// using System.Collections.Generic;

// namespace EcommerceApp2259.Models
// {
//     public class Order
//     {
//         public Guid OrderId { get; }
//         public OrderStatus Status { get; set; }
//         public List<OrderItem> Items { get; }
//         public int TotalCost
//         {
//             get
//             {
//                 int cost = 0;
//                 Items.ForEach(item => cost += item.TotalPrice);
//                 return cost;
//             }
//         }
//     }

// }