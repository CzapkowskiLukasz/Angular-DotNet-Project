using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual User User { get; set; }
    }
}
