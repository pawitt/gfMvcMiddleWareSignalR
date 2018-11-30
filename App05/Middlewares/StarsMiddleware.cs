using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace App05.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class StarsMiddleware
    {
        private int count = 0;
        private readonly RequestDelegate _next;

        public StarsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Items.Add("star",count);
            var req = _next(httpContext);
            count++;
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class StarsMiddlewareExtensions
    {
        public static IApplicationBuilder UseStars(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StarsMiddleware>();
        }
    }
}
