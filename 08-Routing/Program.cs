var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// use Routing for enabling routing
app.UseRouting();

// the endpoints are defined inside this method and map them in endpoints
app.UseEndpoints(endpoints => {
    
});

app.Run();
