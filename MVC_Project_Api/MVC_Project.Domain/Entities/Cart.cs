using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Cart
    {
        public Cart()
        {
            CartProducts = new HashSet<CartProduct>();
            Orders = new HashSet<Order>();
            Users = new HashSet<User>();
        }

        public int CartId { get; set; }
        public decimal? Sum { get; set; }
        public decimal? Weight { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
