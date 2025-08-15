using CleanAndCQRS.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace CleanAndCQRS.Persentation.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {

            if (exception is DomainException customEx)
            {
                httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    errorType = "Domain Exception",
                    message = customEx.Message,
                }, cancellationToken);
            }
            else
            {
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    errorType = "ServerError",
                    message = "An unexpected error occurred."
                }, cancellationToken);
            }
            return true;
        }
    }
}
