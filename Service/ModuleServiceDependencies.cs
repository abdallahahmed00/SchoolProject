using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using infrastructure.Interface;
using infrastructure.Repositires;
using Microsoft.Extensions.DependencyInjection;
using Service.Abstract;
using Service.AuthServices.Implementation;
using Service.AuthServices.Interfaces;
using Service.Implementation;

    namespace Service
    {
        public static class ModuleServiceDependencies
        {
            public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
            {
            var encryptionKey = "8a4dcaaec64d412380fe4b02193cd26f";
            var encryptionProvider = new GenerateEncryptionProvider(encryptionKey);

            services.AddSingleton<IEncryptionProvider>(encryptionProvider);

            services.AddTransient<IStudentService, StudentService>();
                services.AddTransient<IDepartmentSrvice, DepartmentSrvice>();
                services.AddTransient<IInstructorService, InstructorService>();
                services.AddTransient<IAuthenticationService, AuthenticationService>();
                services.AddTransient<IApplicationUserService, ApplicationUserService>();
                services.AddTransient<IEmailService, EmailService>();
                services.AddTransient<ICurrentUserService, CurrentUserService>();
                services.AddTransient<IFileService, FileService>();
                services.AddTransient<IAuthorizationService, AuthorizationService>();

            return services;
            }
        }
    }
