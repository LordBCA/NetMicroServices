using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
//Carter
builder.Services.AddCarter();
//MediatR
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
//Marten
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline
//Carter
app.MapCarter();

app.Run();
