using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
        public DateTime Date { get; set; }
        public int AddressId { get; set; }
        public string Comment { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentTypeId { get; set; }
        public int PaymentStatusId { get; set; }
        public int DeliveryId { get; set; }
        public int? VoucherId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual User User { get; set; }
    }
}
