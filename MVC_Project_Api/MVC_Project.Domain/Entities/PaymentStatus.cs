using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public partial class PaymentStatus
    {
        public PaymentStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentStatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
