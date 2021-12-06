namespace MVC_Project.Logic.Admin.Requests
{
    public class AddCategoryRequest
    {
        public string Name { get; set; }

        public int ParentId { get; set; }
    }
}
