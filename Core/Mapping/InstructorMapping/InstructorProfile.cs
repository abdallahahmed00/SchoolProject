using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.InstructorMapping
{
    public partial class InstructorProfile :Profile
    {
      public InstructorProfile() 
        {
            GetAllInstructorMapping();
            GetInstructorByIdMapping();
        }
    }

}
