using GlowingSystem.BusinessLogic;
using GlowingSystem.Core.Interfaces.Repositories;
using GlowingSystem.Core.Interfaces.Services;
using GlowingSystem.DataAccess;
using GlowingSystem.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GlowingSystem.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Add CORS with policy to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddPolicy("GlowingSystemCorsPolicy", p =>
                {
                    p.AllowAnyOrigin()
                    .WithHeaders().AllowAnyHeader()
                    .WithMethods().AllowAnyMethod();
                });
            });
        }

        /// <summary>
        /// Add DB context to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GlowingSystemDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("GlowingSystem")));
        }

        public static void ConfigureInMemorySqlContext(this IServiceCollection services)
        {
            services.AddDbContext<GlowingSystemDbContext>(opts => opts.UseInMemoryDatabase("GlowingSystemTestDb"));
        }

        /// <summary>
        /// Add business layer services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IContractorService, ContractorService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProjectService, ProjectService>();

            return services;
        }

        /// <summary>
        /// Add data access repositories to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IContractorRepository, ContractorRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            return services;
        }
    }
}
