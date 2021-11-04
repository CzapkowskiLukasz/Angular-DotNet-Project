using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class DeliveryCompany
    {
        public DeliveryCompany()
        {
            DeliveryTypes = new HashSet<DeliveryType>();
        }

        public int DeliveryCompanyId { get; set; }
        public string Name { get; set; }
        public string BaseTrackingUrl { get; set; }

        public virtual ICollection<DeliveryType> DeliveryTypes { get; set; }
    }
}
