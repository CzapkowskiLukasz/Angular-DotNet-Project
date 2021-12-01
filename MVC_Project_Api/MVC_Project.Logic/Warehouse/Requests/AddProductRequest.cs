namespace MVC_Project.Logic.Warehouse.Requests
{
    public class AddProductRequest
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }
    }
}
