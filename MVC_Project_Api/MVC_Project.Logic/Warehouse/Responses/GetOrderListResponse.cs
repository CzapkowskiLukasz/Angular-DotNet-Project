using System.Collections.Generic;

namespace MVC_Project.Logic.Warehouse.Responses
{
    public class GetOrderListResponse
    {
        public List<OrderListItem> Orders { get; set; }
    }
}