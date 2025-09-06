using Infrastructure.Interface;
using Infrastructure.Repositires;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepositry _instructorRepositry;
        public InstructorService(IInstructorRepositry instructorRepositry) 
        
        {
            _instructorRepositry = instructorRepositry; 
     
        }
        public async Task<List<Instructor>> GetAllInstructor()
        {
         return await   _instructorRepositry.GetTableNoTracking()
                .Include(i=>i.department)
                .Include(i=>i.Ins_Subjects).ThenInclude(s => s.Subject)
                .ToListAsync();
        }
    }

}
