using ApiPruebaIntegrity.DTOs.Response;
using ApiPruebaIntegrity.Exceptions;

namespace ApiPruebaIntegrity.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {

            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                Console.WriteLine("LLegando al middleweare");
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error capturado en el middlweare {}", ex);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is GenericException generic)
            {
                context.Response.StatusCode = generic.Code;
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

           var errrorResponse = new GenericRespDTO<string>("ERROR", exception.Message, null);

            return context.Response.WriteAsJsonAsync(errrorResponse);
        }
    }
}
