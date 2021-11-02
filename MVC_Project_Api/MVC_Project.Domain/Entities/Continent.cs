using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public partial class Continent
    {
        public Continent()
        {
            Countries = new HashSet<Country>();
        }

        public int ContinentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
