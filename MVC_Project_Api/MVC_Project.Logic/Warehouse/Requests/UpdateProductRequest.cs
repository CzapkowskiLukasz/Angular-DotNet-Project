namespace MVC_Project.Logic.Warehouse.Requests
{
    public class UpdateProductRequest
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }
    }
}
