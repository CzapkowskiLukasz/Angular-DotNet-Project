using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public partial class Country
    {
        public Country()
        {
            Products = new HashSet<Product>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public int ContinentId { get; set; }
        public string FlagUri { get; set; }

        public virtual Continent Continent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
