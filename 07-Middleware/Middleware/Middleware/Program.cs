using Middleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<UseMyCustomMiddleware>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// creating a middleware terminating middleware 
// app.Run(async (HttpContext context)=>
// {
//     await context.Response.WriteAsync("Introduction to Terminating Middleware");
// });

// creating a middleware intermediate and start middleware using app.Use()

// middleware 01
// app.Use(async (HttpContext context, RequestDelegate next)=>{
//     await context.Response.WriteAsync("This is middleware 01 starts\n");
//     await next(context);
//     await context.Response.WriteAsync("This is middleware 01 ends\n");
// });

// // middleware 02
// app.Use(async (HttpContext context, RequestDelegate next)=>{
//     await context.Response.WriteAsync("This is middleware 02 starts\n");
//     await next(context);
//     await context.Response.WriteAsync("This is middleware 02 ends\n");
// });

// // middleware 03
// app.Run(async (HttpContext context)=>{
//     await context.Response.WriteAsync("This is middleware 03 starts\n");
//     await context.Response.WriteAsync("This is middleware 03 ends\n");
// });

// the above example uses middleware chaining

// creating middleware classes
// app.UseMiddleware<UseMyCustomMiddleware>();

// app.Run(async (HttpContext context)=>{
//     await context.Response.WriteAsync("This is the Program class middleware\n");
// });

// creating middleware extension classes
app.UseMyCustomMiddlewareExtension();

app.Run();
