namespace MVC_Project.Logic.Responses
{
    public class GetOrderByIdResponse
    {
        public int OrderId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserPhoneNumber { get; set; }

        public string AddressInOneString { get; set; }

        public string Comment { get; set; }

        public string Status { get; set; }

        public string Date { get; set; }
    }
}