using Microsoft.AspNetCore.Http;
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
        public Task<bool> IsNameExist(string Name);
        public Task<bool> IsNameExistExcludeSelf(string Name,int Id);
        public Task<string> AddInstructorAsync(Instructor instructor, IFormFile formFile);
        public Task<string>UpdateInstructorImageAsync(int Id  , IFormFile formFile);
        public Task<bool> IsNameExistById(int Id);

    }
}
