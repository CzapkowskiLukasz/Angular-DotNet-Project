namespace MVC_Project.Logic.Requests
{
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
