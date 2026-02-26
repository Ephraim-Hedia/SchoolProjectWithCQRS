using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<Interfaces.IStudentRepository, Repositories.StudentRepository>();
            return services;
        }
    }
}
