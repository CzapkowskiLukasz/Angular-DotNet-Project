namespace MVC_Project.Logic.Admin.Requests
{
    public class UpdateCountryRequest
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

        public int ContinentId { get; set; }
    }
}
