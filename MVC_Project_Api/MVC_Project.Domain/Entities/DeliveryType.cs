using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public partial class DeliveryType
    {
        public DeliveryType()
        {
            Deliveries = new HashSet<Delivery>();
        }

        public int DeliveryTypeId { get; set; }
        public int DeliveryCompanyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal MaxWeight { get; set; }

        public virtual DeliveryCompany DeliveryCompany { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
