var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// creating a middleware terminating middleware 
// app.Run(async (HttpContext context)=>
// {
//     await context.Response.WriteAsync("Introduction to Terminating Middleware");
// });

app.Run();
