using Carter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();

var app = builder.Build();

// Configure the HTTP Request Handler.
app.MapCarter();

app.Run();