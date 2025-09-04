using infrastructure.Interface;
using infrastructure.Repositires;
using Infrastructure.InfrastructureBase;
using Infrastructure.Interface;
using Infrastructure.Repositires;
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
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
            }

        }
    }
