using Data.Entities;
using infrastructure.Data;
using Infrastructure.InfrastructureBase;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositires
{
    public class DepartmentRepositry : GenericRepositoryAsync<Department> , IDepartmentRepositry
    {
        private readonly DbSet<Department> _Department;
        public DepartmentRepositry(AppDbContext context) : base(context)
        {
            _Department = context.Set<Department>();
        }

        public async Task<List<Department>> GetNumberOfInstructorinDepartment()
        {
           return await _Department.Include(x=>x.Instructors).ToListAsync();
        }

       
        public async Task<Department> GetDepartmentWithSubjectsAsync(int id)
        {
            return await 
                _Department
                .Include(d => d.DepartmentSubjects)
                .FirstOrDefaultAsync(d => d.DID == id);
        }

        public async Task<Department> GetDepartmentWithInstructorAsync(int id)
        {
            return await
                           _Department
                           .Include(d => d.Instructor)
                           .FirstOrDefaultAsync(d => d.DID == id);
        }
    }
}
