using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaggerAppBE.Services;
using TaggerAppBE.Utilities.JWTUtils;

namespace TaggerAppBE.Utilities
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JWTMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings.Value;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJWTUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
            var userId = jwtUtils.ValidateJWTToken(token);
            if (userId!=Guid.Empty)
            {
                httpContext.Items["User"] = userService.GetById(userId);
            }

            await _next(httpContext);
        }
    }
}
