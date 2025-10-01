using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<Student> GetByIdAsync(int Id);
        public Task<Student> GetStudentByIdWithIncludeAsync(int Id);
        public Task<Student> GetStudentByNameAsync(string Name);
        public Task<string>AddStudentAsync(Student student);
        public Task<string>EditStudentAsync(Student student);
        public Task<string> DeleteStudentAsync(Student student);
        public Task<List<Student>> FilterStudentsAsync(decimal? grade = null, string? name = null,
            string? address = null,
            string? phone = null, int? departmentid = null, int? studentid = null);

    }

}
