using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backendapi.Middleware
{
    public class NullExceptionHandlingMiddleware
   {
    private readonly RequestDelegate _next;

    public NullExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        { 
            await _next(context);
        }
        catch (NullReferenceException ex)
        {
            await HandleNullReferenceExceptionAsync(context, ex);
        }
    }

    private static Task HandleNullReferenceExceptionAsync(HttpContext context, NullReferenceException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var response = new
        {
            message = "A null reference error occurred.",
            details = exception.Message
        };

        return context.Response.WriteAsJsonAsync(response);
    }

   }
}