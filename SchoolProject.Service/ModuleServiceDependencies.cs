using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Implementation;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }

    }
}
