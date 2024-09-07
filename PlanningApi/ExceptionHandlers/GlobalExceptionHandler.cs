using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Planning.Domain.Exceptions.PlanningService;

namespace PlanningAPI.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails problemDetails;
            if (exception is NotFoundException)
            {
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "An error occurred while processing your request.",
                    Detail = exception.Message
                };
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            else if (exception is IllegalArgumentException || exception is ValidationException)
            {
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status422UnprocessableEntity,
                    Title = "An error occurred while processing your request.",
                    Detail = exception.Message
                };
                httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            }
            else
            {
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "An error occurred while processing your request.",
                    Detail = exception.Message
                };
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            _logger.LogError(exception.Message);
            httpContext.Response.ContentType = "application/problem+json";
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
