using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAapplicationServices(builder.Configuration);
//JWT Authentication
builder.Services.AddIdentityServices(builder.Configuration);
var app = builder.Build();

//configure the HTTP request pipeline
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200"));

//do you have a valid token
app.UseAuthentication();
//what are you allowed to do
app.UseAuthorization();

app.MapControllers();

app.Run();
