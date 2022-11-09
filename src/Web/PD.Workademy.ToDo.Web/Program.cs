using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Application.Services;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;
using PD.Workademy.ToDo.Infrastructure.Persistance;
using PD.Workademy.ToDo.Infrastructure.Persistance.Repositories;
using PD.Workademy.ToDo.Web;
using Serilog;


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureService(builder.Services);

var app = builder.Build();
startup.Configure(app);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();