using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.CompilerServices;
using TechStore.API.Error;
using TechStore.API.Filter;
using TechStore.API.Middleware;
using TechStore.Application;
using TechStore.Application.Common.Interfaces.Authentication;
using TechStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterMiddleware>());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(c =>
    {
    });

}

app.UseExceptionHandler("/errorHandle");
//app.UseMiddleware<ErrorMiddlewareHandle>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
