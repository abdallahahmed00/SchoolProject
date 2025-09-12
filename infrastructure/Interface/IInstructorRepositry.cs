using Infrastructure.InfrastructureBase;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IInstructorRepositry :IGenericRepositoryAsync<Instructor>

    {

        public Task<decimal> GetTotalSalaryForInstructor();
    }
}
