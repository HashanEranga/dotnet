
namespace Middleware.Middlewares {

    class UseMyCustomMiddleware : IMiddleware{

        public async Task InvokeAsync(HttpContext context, RequestDelegate next){
            // before logic
            await context.Response.WriteAsync("This is the custom middleware class\n");
            await next(context);
            // after logic
        }
    }

    public static class UseMyCustomMiddlewareExtension{
        public static IApplicationBuilder AppyMyCustomMiddlewareExtension(this IApplicationBuilder app){
            return app.UseMiddleware<UseMyCustomMiddleware>();
        }
    }
}