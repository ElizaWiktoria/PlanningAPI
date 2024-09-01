﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlanningAPI.Exceptions.PlanningService;

namespace PlanningAPI.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        //private readonly ILogger<MyExceptionHandler> _logger;

        //public GlobalExceptionHandler(ILogger<MyExceptionHandler> logger)
        //{
        //    _logger = logger;
        //}
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
                //_logger.LogError(exception, "An unexpected error occurred.");
            }
            else if (exception is CreatePlanGivenRoutineNotFound)
            {
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status422UnprocessableEntity,
                    Title = "An error occurred while processing your request.",
                    Detail = exception.Message
                };
                //_logger.LogError(exception, "An unexpected error occurred.");
            }
            else
            {
                problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "An error occurred while processing your request.",
                    Detail = exception.Message
                };
                //_logger.LogError(exception, "An unexpected error occurred.");
            }

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/problem+json";
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}