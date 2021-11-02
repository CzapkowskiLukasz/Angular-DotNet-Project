using System;
using System.Collections.Generic;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Vouchers = new HashSet<Voucher>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RoleId { get; set; }
        public bool? NewsletterOn { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int LanguageId { get; set; }
        public int TemporaryCartId { get; set; }
        public int ThemeId { get; set; }
        public int ProductOnPageCount { get; set; }
        public int Provider { get; set; }

        public virtual Language Language { get; set; }
        public virtual Role Role { get; set; }
        public virtual Cart TemporaryCart { get; set; }
        public virtual Theme Theme { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
