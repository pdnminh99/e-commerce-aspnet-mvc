// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.ComponentModel.DataAnnotations;
// using EcommerceApp2259.Models;

// namespace EcommerceApp2259.Models
// {
//     [Table("Order")]
//     public class Order
//     {
//         [Key]
//         public Guid OrderId { get; }

//         [Column("Status")]
//         private string _status
//         {
//             set
//             {
//                 Status = value switch
//                 {
//                     "pending" => OrderStatus.PENDING,
//                     "delivered" => OrderStatus.DELIVERED,
//                     "canceled" => OrderStatus.CANCEL,
//                     _ => OrderStatus.PENDING
//                 };
//             }
//         }

//         [NotMapped]
//         public OrderStatus Status { get; set; }

//         [Column("")]
//         public ICollection<OrderItem> Items { get; }

//         [NotMapped]
//         public int TotalCost
//         {
//             get
//             {
//                 int cost = 0;
//                 foreach (var item in Items) {
//                     cost += item.TotalPrice;
//                 }
//                 return cost;
//             }
//         }
//     }
// }