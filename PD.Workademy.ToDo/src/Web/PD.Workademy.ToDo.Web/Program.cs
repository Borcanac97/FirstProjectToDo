using Microsoft.EntityFrameworkCore;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Application.Services;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;
using PD.Workademy.ToDo.Infrastructure.Persistance;
using PD.Workademy.ToDo.Infrastructure.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Todo"));
});


builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IToDoItemService, ToDoItemService>();


builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IToDoItemRepository, ToDoItemRepository>();



var app = builder.Build();

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