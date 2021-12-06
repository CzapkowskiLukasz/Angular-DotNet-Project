using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public decimal? Sum { get; set; }
        public decimal? Weight { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual User User { get; set; }
    }
}
