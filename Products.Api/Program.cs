using Products.Api.Routes;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Logging.AddConsole();
builder.Services.AddScoped<ProductRoutes>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider.GetService<ProductRoutes>();
service.RegisterProductRoutes(app);
app.Run();