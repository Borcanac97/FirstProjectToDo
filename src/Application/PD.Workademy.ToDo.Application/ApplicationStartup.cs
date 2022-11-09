using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PD.Workademy.ToDo.Application.IServices;
using PD.Workademy.ToDo.Application.Services;

namespace PD.Workademy.ToDo.Application
{
    public class ApplicationStartup
    {
        public ApplicationStartup(IConfigurationRoot configurationRoot)
        {
            Configuration = configurationRoot;
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureService(IServiceCollection service)
        {
            service.AddTransient<ICategoryService, CategoryService>();
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IToDoItemService, ToDoItemService>();
        }
    }
}
