namespace MVC_Project.Logic.Customer.Responses
{
    public class UserCartListItem
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        
        public int Count { get; set; }

        public decimal PricePerItem { get; set; }

        public decimal Price { get; set; }
    }
}