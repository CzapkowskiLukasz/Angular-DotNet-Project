using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<DiscountProduct> ProductDiscounts { get; set; }
    }
}
