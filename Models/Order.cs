using System;
using System.Collections.Generic;

namespace EcommerceApp2259.Models
{
    public class Order
    {
        public Guid OrderId { get; }
        public OrderStatus status { get; set; }
        public List<OrderItem> items { get; }
        public int totalCost
        {
            get
            {
                int cost = 0;
                items.ForEach(item => cost += item.totalPrice);
                return cost;
            }
        }
    }

}