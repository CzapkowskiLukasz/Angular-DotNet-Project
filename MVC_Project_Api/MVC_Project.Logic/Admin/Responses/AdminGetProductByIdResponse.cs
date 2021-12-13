namespace MVC_Project.Logic.Admin.Responses
{
    public class AdminGetProductByIdResponse
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int ProducerId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public int CategoryId { get; set; }
    }
}
