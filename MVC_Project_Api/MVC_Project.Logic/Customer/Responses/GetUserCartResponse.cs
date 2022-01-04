using System.Collections.Generic;

namespace MVC_Project.Logic.Customer.Responses
{
    public class GetUserCartResponse
    {
        public List<UserCartListItem> Products { get; set; }
    }
}