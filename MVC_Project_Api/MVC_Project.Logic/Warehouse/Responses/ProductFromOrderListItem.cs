namespace MVC_Project.Logic.Warehouse.Responses
{
    public class ProductFromOrderListItem
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal PricePerItem { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}