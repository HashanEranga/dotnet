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

    endpoints.MapGet("/products/{id=1}", async context =>
    {
        string? prodId = Convert.ToString(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Product id is {prodId}");
    });

    // optional parameters
    endpoints.MapGet("/product/{id?}", async context =>
    {
        string? prodId = Convert.ToString(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Product id is {prodId}");
    });
});

// Route Constraints
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("store/newspaper/{id:int}", async context =>
    {
        int paperId = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Paper id is {paperId}");
    });

    endpoints.MapGet("login/{isAuthorized:bool}", async context =>
    {
        Boolean isAuthorized = Convert.ToBoolean(context.Request.RouteValues["isAuthorized"]);
        if (isAuthorized) await context.Response.WriteAsync("User Authorized");
        else await context.Response.WriteAsync("User not Authorized");
    });

    endpoints.MapGet("daily-digest-report/{reportdate:datetime}", async context =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"Report date for the digestion : {reportDate.ToShortDateString()}");
    });

    endpoints.MapGet("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"city id is : {cityId}");
    });

    endpoints.MapGet("cityid", async context =>
    {
        Guid cityIdGuid = new();
        await context.Response.WriteAsync($"{cityIdGuid}");
    });

    endpoints.MapGet("student/profile/{firstname:minlength(4)}", async context =>
    {
        string? stuName = Convert.ToString(context.Request.RouteValues["firstname"]);
        await context.Response.WriteAsync($"student's first name is : {stuName}");
    });
});

// configure for other paths were added
app.Run(async context =>
{
    await context.Response.WriteAsync($"Request path is {context.Request.Path}");
});

app.Run();
