using MVC_Project.Domain.Entities;
using System;

namespace MVC_Project.Logic.Responses
{
    public class OrderListItem
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}