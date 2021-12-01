namespace MVC_Project.Logic.Admin.Requests
{
    public class AdminAddProductRequest
    {
        public string Name { get; set; }

        public int ProducerId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public int CategoryId { get; set; }
    }
}
