namespace MVC_Project.Logic.Commons
{
    public class HandleResult<T>
    {
        public T Response { get; set; }

        public ErrorResponse ErrorResponse { get; set; }
    }
}
