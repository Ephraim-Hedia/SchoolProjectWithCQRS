using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Interfaces;
using SchoolProject.Service.Implementation;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }

    }
}
