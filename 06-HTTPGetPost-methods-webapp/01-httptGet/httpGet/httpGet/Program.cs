var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    // set the content type to text/html
    context.Response.Headers["Content-type"] = "text/html";

    // check for custom header metadata
    if (context.Request.Headers.ContainsKey("Authorization-key"))
    {
        string authKey = context.Request.Headers["Autherization-Key"];
        await context.Response.WriteAsync($"<p>{authKey}</p>");
    }
});

app.Run();
