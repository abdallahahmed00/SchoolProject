using infrastructure.Interface;
using infrastructure.Repositires;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.Implementation;

    namespace Service
    {
        public static class ModuleServiceDependencies
        {
            public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
            {
                services.AddTransient<IStudentService, StudentService>();
                services.AddTransient<IDepartmentSrvice, DepartmentSrvice>();
                services.AddTransient<IInstructorService, InstructorService>();
                services.AddTransient<IAuthenticationService, AuthenticationService>();
                return services;
            }
        }
    }
