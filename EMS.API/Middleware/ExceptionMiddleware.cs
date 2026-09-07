using System.Net;
using System.Text.Json;

namespace EMS.API.Middleware
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
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Something went wrong!",
                    Error = ex.Message
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}