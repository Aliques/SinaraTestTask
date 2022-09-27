using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserManagement.Data;
using UserManagement.Data.Profiles;
using UserManagement.Data.Repositories;

namespace UserManagementService.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseInMemoryDatabase("InMem"));
        }

        public static void ServicesCofiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(UsersProfiles)));
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
