using System;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int DeliveryTypeId { get; set; }
        public string ShipmentIdFromDeliveryCompany { get; set; }
        public string TrackingUrl { get; set; }
        public DateTime SendDate { get; set; }

        public virtual DeliveryType DeliveryType { get; set; }
    }
}
