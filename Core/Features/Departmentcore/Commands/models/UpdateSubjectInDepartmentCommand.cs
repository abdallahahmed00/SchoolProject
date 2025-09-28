using Core.Basis;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Departmentcore.Commands.models
{
    public class UpdateSubjectInDepartmentCommand :IRequest<Response<string>>
    {
        public int DID { get; set; }
        public virtual ICollection<UpdateSubjects>SubjectsId { get; set; }
    }
    public class UpdateSubjects
    { 
    public int SubId { get; set; }
    }

}
