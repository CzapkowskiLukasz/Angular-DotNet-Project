using Microsoft.AspNetCore.Http;
using MVC_Project.Logic.Commons;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVC_Project.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var errorResponse = new ErrorResponse(e?.Message, response.StatusCode);

                var jsonResult = JsonSerializer.Serialize(errorResponse);
                await response.WriteAsync(jsonResult);
            }
        }
    }
}
