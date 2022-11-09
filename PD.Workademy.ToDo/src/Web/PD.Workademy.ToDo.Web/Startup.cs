
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Application.Services;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;
using PD.Workademy.ToDo.Infrastructure.Persistance.Repositories;
using PD.Workademy.ToDo.Infrastructure.Persistance;
using Serilog;
using Microsoft.EntityFrameworkCore;

namespace PD.Workademy.ToDo.Web
{
    public class Startup
    {
        public Startup(IConfigurationRoot configurationRoot)
        {
            Configuration = configurationRoot;
        }
        public IConfigurationRoot Configuration { get;}

        public void ConfigureService(IServiceCollection service)
        {
            service.AddControllers();
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();

            service.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Todo"));
            });


            service.AddTransient<ICategoryService, CategoryService>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IToDoItemService, ToDoItemService>();


            service.AddTransient<ICategoryRepository, CategoryRepository>();
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IToDoItemRepository, ToDoItemRepository>();

            static IHostBuilder CreateHostBuilder(string[] args) =>
                       Host.CreateDefaultBuilder(args)
                           .UseWindowsService()
                           .UseSerilog((context, config) =>
                           {
                               config.ReadFrom.Configuration(context.Configuration);
                           });

        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseRouting();

            application.UseEndpoints(x=>x.MapControllers());
        }
    
    
    }
}
