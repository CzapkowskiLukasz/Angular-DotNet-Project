using System;
using System.Collections.Generic;

namespace MVC_Project.Logic.Admin.Responses
{
    public class AdminGetUserById
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
    }
}