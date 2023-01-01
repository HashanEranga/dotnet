var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Headers.ContainsKey("Auth-Key"))
    {
        string authKey = context.Request.Headers["Auth-Key"];
        await context.Response.WriteAsync($"<p>{authKey}</p>");
    }
});

app.Run();
