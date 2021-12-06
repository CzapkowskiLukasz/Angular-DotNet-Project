using System;

namespace MVC_Project.Logic.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        
        public TimeSpan TokenLifeTime { get; set; }
    }
}
