using PD.Workademy.ToDo.Application;
using PD.Workademy.ToDo.Web;


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
var applicationStartup = new ApplicationStartup(builder.Configuration);

startup.ConfigureService(builder.Services);
applicationStartup.ConfigureService(builder.Services);

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