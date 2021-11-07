#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class DiscountProduct
    {
        public int ProductId { get; set; }
        public int DiscountId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Product Product { get; set; }
    }
}
