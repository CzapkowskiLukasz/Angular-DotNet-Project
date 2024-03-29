﻿using System;

#nullable disable

namespace MVC_Project.Domain.Entities
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public decimal Rebate { get; set; }
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int? Status { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
