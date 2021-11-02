using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
