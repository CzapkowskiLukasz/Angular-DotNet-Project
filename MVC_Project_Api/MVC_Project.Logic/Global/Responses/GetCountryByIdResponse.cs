namespace MVC_Project.Logic.Global.Responses
{
    public class GetCountryByIdResponse
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

        public int ContinentId { get; set; }

        public string ContinentName { get; set; }
    }
}