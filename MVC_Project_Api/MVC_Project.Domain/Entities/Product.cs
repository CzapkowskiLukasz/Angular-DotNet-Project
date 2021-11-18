using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int WarehouseQuantity { get; set; }
        public int? ExpertId { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? DiscountId { get; set; }
        public DateTime CreateDate { get; set; }
        public int? ProducerId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User Expert { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<DiscountProduct> ProductDiscounts { get; set; }
    }
}
