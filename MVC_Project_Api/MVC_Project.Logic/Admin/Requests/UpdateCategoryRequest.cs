namespace MVC_Project.Logic.Admin.Requests
{
    public class UpdateCategoryRequest
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }
    }
}
