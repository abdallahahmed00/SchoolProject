using Data.Entities;
using Data.Entities.View;
using Infrastructure.Interface;
using Infrastructure.Interface.View;
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
        private readonly IViewRepository<ViewDepartment> _viewRepository;
        public DepartmentSrvice (IDepartmentRepositry department, IViewRepository<ViewDepartment> viewRepository)
        {
            _departmentrepo = department;   
            _viewRepository = viewRepository;
        }

        public async Task <string> AddDepartmentAsync(Department department)
        {
            var check = await IsDepartmentExistByName(department.DName);

            if (check) 
            {
                return "It is Exist";
            }

            await _departmentrepo.AddAsync(department);
            return "Success";

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

        public async Task<List<ViewDepartment>> GetCountStudentInDepartmentAsync()
        {
            var ViewDepartment =await _viewRepository.GetTableNoTracking().ToListAsync();
            return ViewDepartment;
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

        public async Task<List<Department>> GetNumberOfInstructorinDepartment()
        {
          return await  _departmentrepo.GetNumberOfInstructorinDepartment();
        }

        public  async Task<bool> IsDepartmentExist(int DepartmentID)
        {
           return await  _departmentrepo?.GetTableNoTracking().AnyAsync(X => X.DID.Equals( DepartmentID));
        }

        public async Task<bool> IsDepartmentExistByName(string Name)
        {
            return await _departmentrepo.GetTableNoTracking()
       .AnyAsync(d => d.DName == Name);
        }

        public async Task<string> UpdateManagerDepartment(Department department)
        {
            var existingDepartment = await _departmentrepo.GetDepartmentWithInstructorAsync(department.DID);
            if (existingDepartment == null)
            {
                return "Department Not Found";
            }
            existingDepartment.InsManager = department.InsManager;
            await _departmentrepo.UpdateAsync(existingDepartment);
            return "Success";
        }

        public async Task<string> UpdateSubjectInDepartment(Department department)
        {
            var existingDepartment = await _departmentrepo.GetDepartmentWithSubjectsAsync(department.DID);

            if (existingDepartment == null)
            {
                return "Department Not Found";
            }
            existingDepartment.DepartmentSubjects.Clear();
            foreach (var subject in department.DepartmentSubjects)
            {
                existingDepartment.DepartmentSubjects.Add(new DepartmetSubject
                {
                    DID = existingDepartment.DID,
                    SubID = subject.SubID
                });
            }
            await _departmentrepo.UpdateAsync(existingDepartment);
            return "Success";


        }
    }
}
