namespace MVC_Project.Logic.Commons
{
    public class ErrorResponse
    {
        public ErrorResponse(string message, int errorCode = 0)
        {
            Message = message;
            ErrorCode = errorCode;
        }

        public string Message { get; set; }

        public int ErrorCode { get; set; }
    }
}