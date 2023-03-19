using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OrdersManager.DBcontext;

namespace OrdersManager.Models
{
    public class OrderWithItems
    {   
        public OrderWithItems(Order order, List<OrderItem> items)
        {
            Order = order;
            OrderItems = items;
        }
        public Order Order { get; set; }

        public List<OrderItem>? OrderItems { get; set; }
    }
}
