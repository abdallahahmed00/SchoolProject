using Data.Entities;
using Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IDepartmentRepositry :IGenericRepositoryAsync<Department>
    {
        public Task<List< Department>> GetNumberOfInstructorinDepartment();
    }
}
