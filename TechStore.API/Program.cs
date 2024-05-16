using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.CompilerServices;
using TechStore.API;
using TechStore.API.Error;
using TechStore.API.Filter;
using TechStore.API.Middleware;
using TechStore.Application;
using TechStore.Application.Common.Interfaces.Authentication;
using TechStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);


//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterMiddleware>());

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
