using System;

namespace MVC_Project.Logic.Admin.Responses
{
    public class AdminDiscountListItem
    {
        public int DiscountId { get; set; }

        public string Name { get; set; }

        public decimal Percent { get; set; }

        public DateTime EndDate { get; set; }
    }
}
