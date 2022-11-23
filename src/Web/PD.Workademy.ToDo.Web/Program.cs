using PD.Workademy.ToDo.Application;
using PD.Workademy.ToDo.Infrastructure;
using PD.Workademy.ToDo.Web;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});


var startup = new Startup(builder.Configuration);
var applicationStartup = new ApplicationStartup(builder.Configuration);
var infrastructureStartup= new InfrastructureStartup(builder.Configuration);

startup.ConfigureService(builder.Services);
applicationStartup.ConfigureService(builder.Services);
infrastructureStartup.ConfigureService(builder.Services);

startup.ConfigureService(builder.Services);
var app = builder.Build();
startup.Configure(app);


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.Run();