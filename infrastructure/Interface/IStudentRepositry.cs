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
        public Task<List<Student>> FilterAsync(decimal? Grade = null, string? Name = null,string?address=null
            ,string?phone=null ,int?departmentid=null,int? studentid = null);

    }
}
