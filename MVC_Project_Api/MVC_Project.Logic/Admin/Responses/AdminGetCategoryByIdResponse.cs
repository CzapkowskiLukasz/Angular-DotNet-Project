namespace MVC_Project.Logic.Admin.Responses
{
    public class AdminGetCategoryByIdResponse
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }
    }
}
