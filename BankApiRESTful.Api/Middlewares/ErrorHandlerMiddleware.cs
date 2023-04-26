using BankApiRESTful.Application.Wrappers;
using BankApiRESTful.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace BankApiRESTful.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext content)
        {
            try
            {
                await _next(content);
            }
            catch (Exception error)
            {
                var response = content.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() 
                { 
                    Succeeded = false,
                    Message = error?.Message
                };

                switch (error)
                {
                    case ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;

                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
