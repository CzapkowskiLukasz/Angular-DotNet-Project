namespace MVC_Project.Logic.Responses
{
    public class GetProductByIdResponse
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int WarehouseQuantity { get; set; }

        public string CategoryName { get; set; }

        public string ProducerName { get; set; }
    }
}