using Data.Entities;
using infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepositry _studentRepositry;

        public StudentService(IStudentRepositry studentRepositry) 
        {
            _studentRepositry = studentRepositry;
        }

        public async Task<string> AddStudentAsync(Student student)
        {
            //var studentresult = _studentRepositry.GetTableNoTracking()
            //    .Where(x => x.Name.Equals( student.Name)).SingleOrDefault();
            //if (studentresult!=null)
            //{
            //    return "Exist";
            //}
          await  _studentRepositry.AddAsync(student);
            return "Success";
        }

        public async Task<string> DeleteStudentAsync(Student student)
        {
            var trans = _studentRepositry.BeginTransaction();
            try
            {
                await _studentRepositry.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditStudentAsync(Student student)
        {
           await _studentRepositry.UpdateAsync(student);
            return "Success";
        }

        public async Task<Student> GetByIdAsync(int Id)
        {
            var student =await _studentRepositry.GetByIdAsync(Id);
            return student;
        }

        public async Task<Student> GetStudentByIdWithIncludeAsync(int Id)
        {
            var student=  _studentRepositry.GetTableNoTracking()
                .Include(x=>x.Department)
                .Where(x=>x.StudID.Equals(Id)).FirstOrDefault();
            return  student;
        }

        public Task<Student> GetStudentByNameAsync(string Name)
        {
            var student = _studentRepositry.GetTableNoTracking()
                .Include(x => x.Department).Where(x => x.Name.Equals(Name)).FirstOrDefaultAsync();
            return student;
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
          return await  _studentRepositry.GetStudentListAsync();
        }
    }
}
