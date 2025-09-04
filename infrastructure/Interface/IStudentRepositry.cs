using Data.Entities;
using Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Interface
{
    public interface IStudentRepositry :IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentListAsync();

        public  Task<Student> GetStudentByNameAsync(string Name); 

    }
}
