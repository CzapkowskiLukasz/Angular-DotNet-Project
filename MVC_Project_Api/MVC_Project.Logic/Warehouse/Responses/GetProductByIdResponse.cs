namespace MVC_Project.Logic.Warehouse.Responses
{
    public class GetProductByIdResponse
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int WarehouseQuantity { get; set; }

        public string CategoryName { get; set; }

        public string ProducerName { get; set; }
    }
}