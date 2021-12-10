namespace MVC_Project.Logic.Admin.Requests
{
    public class UpdateProducerRequest
    {
        public int ProducerId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
