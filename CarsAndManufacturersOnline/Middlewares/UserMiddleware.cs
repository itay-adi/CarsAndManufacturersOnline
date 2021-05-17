using CarsAndManufacturersOnline.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturersOnline.Middlewares
{
    public class UserMiddleware
    {
        private RequestDelegate _next;

        public UserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICurrentUserService currentUser)
        {
            var userName = context.Request.Headers["user"].ToString();

            await currentUser.SetCurrentUser(userName);
            await _next(context);
        }
    }

    public static class UserMiddlewareExtension
    {
        public static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UserMiddleware>();
        }
    }
}
