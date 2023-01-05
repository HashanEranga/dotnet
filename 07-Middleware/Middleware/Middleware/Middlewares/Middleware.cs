using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Middleware.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //before logic
            if(httpContext.Request.Query.ContainsKey("firstName") && httpContext.Request.Query.ContainsKey("lastName"))
            {
                string fullName = httpContext.Request.Query["firstname"] + " " + httpContext.Request.Query["lastName"];
                await httpContext.Response.WriteAsync(fullName);
            }
            await _next(httpContext);
            //after logic
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassConventional(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}

