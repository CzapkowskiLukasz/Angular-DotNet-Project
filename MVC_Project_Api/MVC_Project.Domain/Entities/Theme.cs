using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Theme
    {
        public int ThemeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
