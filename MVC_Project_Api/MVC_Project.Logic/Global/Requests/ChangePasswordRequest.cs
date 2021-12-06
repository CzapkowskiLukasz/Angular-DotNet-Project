namespace MVC_Project.Logic.Global.Requests
{
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
