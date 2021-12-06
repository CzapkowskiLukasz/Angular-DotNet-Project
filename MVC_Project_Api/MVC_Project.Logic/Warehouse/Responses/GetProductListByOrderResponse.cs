using System.Collections.Generic;

namespace MVC_Project.Logic.Warehouse.Responses
{
    public class GetProductListByOrderResponse
    {
        public List<ProductFromOrderListItem> Products { get; set; }

        public decimal Sum { get; set; }

        public decimal Weight { get; set; }
    }
}