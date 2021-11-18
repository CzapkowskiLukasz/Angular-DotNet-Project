using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool? NewsletterOn { get; set; }
        public int? LanguageId { get; set; }
        public int? TemporaryCartId { get; set; }
        public int? ThemeId { get; set; }
        public int ProductOnPageCount { get; set; }
        public int Provider { get; set; }

        public virtual Language Language { get; set; }
        public virtual Cart TemporaryCart { get; set; }
        public virtual Theme Theme { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}