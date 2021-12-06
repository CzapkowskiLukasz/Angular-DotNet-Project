using Microsoft.AspNetCore.Http;
using MVC_Project.Logic.Settings;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.Api.Middlewares
{
    public class SwaggerAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SwaggerSettings _swaggerSettings;

        public SwaggerAuthenticationMiddleware(RequestDelegate next, SwaggerSettings swaggerSettings)
        {
            _next = next;
            _swaggerSettings = swaggerSettings;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    var encodedLoginPassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();

                    var decodedLoginPassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedLoginPassword)).Split(':', 2);

                    var login = decodedLoginPassword[0];
                    var password = decodedLoginPassword[1];

                    if (IsAuthenticated(login, password))
                    {
                        await _next.Invoke(context);
                        return;
                    }
                }

                context.Response.Headers["WWW-Authenticate"] = "Basic";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                await _next.Invoke(context);
            }
        }

        public bool IsAuthenticated(string login, string password)
        {
            return login.Equals(_swaggerSettings.Login, StringComparison.InvariantCultureIgnoreCase)
                    && password.Equals(_swaggerSettings.Password);
        }
    }
}
