using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAapplicationServices(builder.Configuration);
//JWT Authentication
builder.Services.AddIdentityServices(builder.Configuration);
var app = builder.Build();

//use middleware to handle errors
app.UseMiddleware<ExceptionMiddleware>();
//configure the HTTP request pipeline
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200"));

//do you have a valid token
app.UseAuthentication();
//what are you allowed to do
app.UseAuthorization();

app.MapControllers();

app.Run();
