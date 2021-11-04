using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Delivery
    {
        public Delivery()
        {
            Orders = new HashSet<Order>();
        }

        public int DeliveryId { get; set; }
        public int DeliveryTypeId { get; set; }
        public string ShipmentIdFromDeliveryCompany { get; set; }
        public string TrackingUrl { get; set; }
        public DateTime SendDate { get; set; }

        public virtual DeliveryType DeliveryType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
