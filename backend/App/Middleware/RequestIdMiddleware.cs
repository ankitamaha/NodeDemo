using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace DockerTestProject.Middleware {

    public static class RequestIdMiddlewareExtensions {
        public static IApplicationBuilder UseRequestId(this IApplicationBuilder builder) {
            return builder.UseMiddleware<RequestIdMiddleware>();
        }
    }

    public class RequestIdMiddleware {
        private readonly RequestDelegate next;

        public RequestIdMiddleware(RequestDelegate next) {
            this.next = next;
        }

        public Task Invoke(HttpContext context) {
            if (!context.Request.Headers.Keys.Contains("X-DTP-Request-ID")) {
                context.Response.Headers.Add("X-DTP-Request-ID", Guid.NewGuid().ToString().Substring(0, 8));
            }
            return this.next(context);
        }
    }
}
