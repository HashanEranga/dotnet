var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// use Routing for enabling routing
app.UseRouting();

// the endpoints are defined inside this method and map them in endpoints
// app.UseEndpoints(endpoints => {
//     // define the default path
//     endpoints.Map("/", async (context) => {
//         await context.Response.WriteAsync("In the default path\n");
//     });

//     // define the first endpoint
//     // work with any http method
//     // endpoints.Map("/map1", async (context) => {
//     //     await context.Response.WriteAsync("In Map 1\n");
//     // });

//     // allow only http specific http methods
//     endpoints.MapGet("/map1", async (context) => {
//         await context.Response.WriteAsync("In Map1 using a get method only")
//     });

//     // define the second endpoint
//     // endpoints.Map("/map2", async (context) => {
//     //     await context.Response.WriteAsync("In Map 2\n");
//     // });

//     // this endpoint will allow only the post methods only
//     endpoints.MapPost("/map2", async (context) => {
//         await context.Response.WriteAsync("In Map2 using a post method only");
//     });
// });

// accessing parameters
//app.UseEndpoints( endpoints => {
//    endpoints.MapGet("/files/{filename}.{extension}", async context => {
//        string? fileName = context.Request.RouteValues["filename"].ToString();
//        string? extension = context.Request.RouteValues["extension"].ToString();
//        await context.Response.WriteAsync($"In files accessed {fileName}.{extension}");
//    });
//});

// adding default parameters
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/employee/profile/{EmpName=ishini}", async context =>
    {
        string? empName = Convert.ToString(context.Request.RouteValues["EmpName"]);
        await context.Response.WriteAsync($"In employee profile - {empName}");
    });
});

// configure for other paths were added
app.Run(async context =>
{
    await context.Response.WriteAsync($"Request path is {context.Request.Path}");
});

app.Run();
