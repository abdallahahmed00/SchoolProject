using Data.Entities;
using Infrastructure.Interface;
using Infrastructure.Repositires;
using Microsoft.EntityFrameworkCore;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class DepartmentSrvice :IDepartmentSrvice
    {
        private readonly IDepartmentRepositry _departmentrepo; 
        public DepartmentSrvice (IDepartmentRepositry department)
        {
            _departmentrepo = department;   
        }
        public async Task<List<Department>> GetAllDepartment()
        {
            return await _departmentrepo.GetTableNoTracking()
                   .Include(d => d.Students)
                   .Include(d => d.DepartmentSubjects)
                   .Include(d => d.Instructors)
                   .Include(d => d.Instructor) 
                   .ToListAsync();
        }
        public async Task<Department> GetDepartmentByIdAsync(int Id)
        {
            var department = await _departmentrepo.GetTableNoTracking()
       .Where(d => d.DID == Id)
       .Include(d => d.Students)
       .Include(d => d.DepartmentSubjects).ThenInclude(ds => ds.Subjects)
       .Include(d => d.Instructors)
       .Include(d => d.Instructor) 
       .FirstOrDefaultAsync();

            return department;
        }
    }
}
