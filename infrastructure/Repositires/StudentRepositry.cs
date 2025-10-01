using Data.Entities;
using infrastructure.Data;
using infrastructure.Interface;
using Infrastructure.InfrastructureBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Repositires
{
    public class StudentRepositry : GenericRepositoryAsync<Student> , IStudentRepositry
    {
     //   private readonly AppDbContext _Context;
        private readonly DbSet<Student> _students;
        private readonly DbSet<StudentSubject> _stdsub;
        private readonly DbSet<Department> _dept;
        public StudentRepositry(AppDbContext context) :base(context) 
        {
            _students = context.Set<Student>();
            _stdsub = context.Set<StudentSubject>();
            _dept = context.Set<Department>();
        }

      

        public  Task<Student> GetStudentByNameAsync(string Name)
        {
            return  _students.FirstOrDefaultAsync(x=>x.Name==Name);
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _students.Include(x=>x.Department).ToListAsync();
        }
        public async Task<List<Student>> FilterAsync(decimal? grade = null, string? name = null, 
            string? address = null, string? phone = null, int? departmentid = null, int? studentid = null)
        {
            var query = _students.Include(s=>s.StudentSubject).ThenInclude(ss => ss.Subject).
                Include(s=>s.Department).AsQueryable();
            if (grade.HasValue)
            {
                query = query.Where(s => s.StudentSubject.Any(s=>s.grade == grade.Value));
            }
            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(s => s.Address.Contains(address));
            }
            if (!string.IsNullOrEmpty(phone))
            {
                query = query.Where(s => s.Phone.Contains(phone));
            }
            if (departmentid.HasValue)
            {
                query = query.Where(s => s.Department.DID == departmentid.Value);
            }
            if (studentid.HasValue)
            {
                query = query.Where(s => s.StudID==studentid.Value);
            }
            return await query.ToListAsync();

        }
    }
}
