using Carter;
using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config => { config.RegisterServicesFromAssembly(typeof(Program).Assembly); });
builder.Services.AddMarten(ops => { ops.Connection(builder.Configuration.GetConnectionString("Connection")); })
    .UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP Request Handler.
app.MapCarter();

app.Run();