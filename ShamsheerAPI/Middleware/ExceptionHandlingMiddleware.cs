using Microsoft.AspNetCore.Http;
using System.Net;

namespace ShamsheerAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //Log Exception
                var errID = Guid.NewGuid();

                _logger.LogError(ex, $"{DateTime.Now.ToString()} - {errID} : {ex.Message}");

                //Return Customer Error Message
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var err = new
                {
                    ID = errID,
                    //ErrorMessage = "Something Went Wrong, Please try again!"
                    ErrorMessage = ex.Message,
                };

                await context.Response.WriteAsJsonAsync(err);
            }
            
        }
    }
}
