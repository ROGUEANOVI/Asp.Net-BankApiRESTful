using BankApiRESTful.Api.Middlewares;

namespace BankApiRESTful.Api.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
