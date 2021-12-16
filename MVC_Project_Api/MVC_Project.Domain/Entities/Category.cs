using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }
        public string SvgLogo { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
