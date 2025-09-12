using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IInstructorService
    {
        public Task <List<Instructor>> GetAllInstructor();
        public Task<Instructor> GetInstructorById(int Id);
            public Task<Instructor> GetInstructorByIdWithoutInclude(int Id);
            public Task<string> DeleteInstructor(Instructor instructor);
        public Task<decimal> GetTotalSalary();
    }
}
