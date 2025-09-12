using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.DepartmentsMspping
{
    public partial class DepartmentProfile :Profile
    {
        public DepartmentProfile() 
        {
            GetDepartmentByIdMapping();
            GetTotalInstructorMapping();

        }
    }
}
