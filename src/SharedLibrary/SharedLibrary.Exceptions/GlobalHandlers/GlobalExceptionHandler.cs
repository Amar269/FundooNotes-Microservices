using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Exceptions.Exceptions;
using SharedLibrary.Exceptions.Responses;
using System.Text.Json;

namespace SharedLibrary.Exceptions.GlobalHandlers
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

            private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            var response = context.Response;

            response.ContentType = "application/json";

            var errorResponse = new ErrorResponse
            {
                Timestamp = DateTime.UtcNow
            };

            switch (exception)
            {
                case ValidationException:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    errorResponse.StatusCode = 400;
                    errorResponse.Message = exception.Message;
                    break;

                case NotFoundException:
                    response.StatusCode = StatusCodes.Status404NotFound;
                    errorResponse.StatusCode = 404;
                    errorResponse.Message = exception.Message;
                    break;

                case ConflictException:
                    response.StatusCode = StatusCodes.Status409Conflict;
                    errorResponse.StatusCode = 409;
                    errorResponse.Message = exception.Message;
                    break;

                case UnauthorizedOperationException:
                    response.StatusCode = StatusCodes.Status401Unauthorized;
                    errorResponse.StatusCode = 401;
                    errorResponse.Message = exception.Message;
                    break;

                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    errorResponse.StatusCode = 500;
                    errorResponse.Message = "Internal Server Error";
                    errorResponse.Details = exception.Message;
                    break;
            }
            var result = JsonSerializer.Serialize(errorResponse);

            await response.WriteAsync(result);

        }
    }
}
