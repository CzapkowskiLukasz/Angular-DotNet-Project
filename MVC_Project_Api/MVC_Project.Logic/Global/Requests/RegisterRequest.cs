namespace MVC_Project.Logic.Global.Requests
{
    public class RegisterRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int LanguageId { get; set; }

        public bool NewsletterOn { get; set; }
    }
}
