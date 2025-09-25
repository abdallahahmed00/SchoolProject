using Data.Entities.View;
using infrastructure.Interface;
using infrastructure.Repositires;
using Infrastructure.InfrastructureBase;
using Infrastructure.Interface;
using Infrastructure.Interface.View;
using Infrastructure.Repositires;
using Infrastructure.Repositires.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
        public static  class ModuleInfrastructureDependencies
        {
            public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
            {
                services.AddTransient<IStudentRepositry, StudentRepositry>();
                services.AddTransient<IDepartmentRepositry, DepartmentRepositry>();
                services.AddTransient<IInstructorRepositry, InstructorRepositry>();
                services.AddTransient<IRefreshTokenRepo, RefreshTokenRepo>();
                services.AddTransient<IViewRepository<ViewDepartment>, ViewDepartmentRepositry>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
            }

        }
    }
