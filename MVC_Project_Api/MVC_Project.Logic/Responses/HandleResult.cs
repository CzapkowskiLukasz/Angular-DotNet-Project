namespace MVC_Project.Logic.Responses
{
    public class HandleResult<T>
    {
        public T Response { get; set; }

        public ErrorResponse ErrorResponse { get; set; }
    }
}
