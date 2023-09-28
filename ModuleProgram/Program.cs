using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModuleProgram.Context;
using ModuleProgram.Interfaces;
using ModuleProgram.Repositories;
using ModuleProgram.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Get configuration 
IConfiguration config = builder.Configuration;

// Get secret key from appsettings.json
string secretKey = config["JwtSettings:SecretKey"];
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

// Configure JWT authentication
builder.Services.AddScoped<JwtService>();

// Configure UserRepository with dependency injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Enable JWT authentication

app.UseAuthorization();

app.MapControllers();

app.Run();
