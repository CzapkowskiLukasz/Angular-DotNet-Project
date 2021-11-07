#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class DeliveryType
    {
        public int DeliveryTypeId { get; set; }
        public int DeliveryCompanyId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal MaxWeight { get; set; }

        public virtual DeliveryCompany DeliveryCompany { get; set; }
    }
}
