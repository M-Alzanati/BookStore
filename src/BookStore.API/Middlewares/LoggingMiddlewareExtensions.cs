using Microsoft.AspNetCore.Builder;

namespace BookStore.API.Middlewares
{
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}