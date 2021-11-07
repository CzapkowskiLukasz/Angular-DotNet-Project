using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
