using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public partial class Product
    {
        public Product()
        {
            CartProducts = new HashSet<CartProduct>();
            ProductDiscounts = new HashSet<ProductDiscount>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int WarehouseQuantity { get; set; }
        public int? ExpertId { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int? DiscountId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CountryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
    }
}
