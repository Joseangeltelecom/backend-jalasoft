using BakeryFreshBread.Core.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace BakeryFreshBread.Infrastructure.Middlewares
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExeptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)ExeptionsStatusCodes.GetExeptionStatusCode(ex);
                await httpContext.Response.WriteAsync(ex.Message);
            }
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExeptionMiddleware>();
        }
    }
}
