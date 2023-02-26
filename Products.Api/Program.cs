using Products.Api.Routes;
var builder = WebApplication.CreateSlimBuilder(args);
builder.Logging.AddConsole();

var app = builder.Build();
app.MapProductRoutes();

app.Run();