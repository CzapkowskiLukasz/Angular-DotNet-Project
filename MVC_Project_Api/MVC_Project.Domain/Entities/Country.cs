using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public int ContinentId { get; set; }
        public string FlagUri { get; set; }

        public virtual Continent Continent { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }
    }
}
