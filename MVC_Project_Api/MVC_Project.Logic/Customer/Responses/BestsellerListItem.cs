namespace MVC_Project.Logic.Customer.Responses
{
    public class BestsellerListItem
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsPricePerItem { get; set; }
    }
}