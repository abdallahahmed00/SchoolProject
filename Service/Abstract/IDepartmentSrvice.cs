using Data.Entities;
using Data.Entities.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IDepartmentSrvice
    {
        public  Task<List<Department>> GetAllDepartment();
        public Task<Department> GetDepartmentByIdAsync(int Id);
        public Task<List<Department>> GetNumberOfInstructorinDepartment();
        public Task<List<ViewDepartment>> GetCountStudentInDepartmentAsync();
        public Task<bool> IsDepartmentExist(int DepartmentID);

    }
}
