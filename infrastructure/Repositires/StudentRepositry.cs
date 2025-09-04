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
        public StudentRepositry(AppDbContext context) :base(context) 
        {
            _students = context.Set<Student>();
        }

        public  Task<Student> GetStudentByNameAsync(string Name)
        {
            return  _students.FirstOrDefaultAsync(x=>x.Name==Name);
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _students.Include(x=>x.Department).ToListAsync();
        }
    }
}
