using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PD.Workademy.ToDo.Domain.SharedKarnel.Interfaces.Repository;
using PD.Workademy.ToDo.Infrastructure.Persistance;
using PD.Workademy.ToDo.Infrastructure.Persistance.Repositories;

namespace PD.Workademy.ToDo.Infrastructure
{
    public class InfrastructureStartup
    {
        public InfrastructureStartup(IConfigurationRoot configurationRoot)
        {
            Configuration = configurationRoot;
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IToDoItemRepository, ToDoItemRepository>();

            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Todo"));
            });
        }
    }
}
