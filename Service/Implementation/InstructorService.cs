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

        public async Task<string> DeleteInstructor(Instructor instructor)
        {
            var trans = _instructorRepositry.BeginTransaction();
            try
            {
            await    _instructorRepositry.DeleteAsync(instructor);
               await trans.CommitAsync();
                return "Success";

            }
           
                 catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }
        

        public async Task<List<Instructor>> GetAllInstructor()
        {
         return await   _instructorRepositry.GetTableNoTracking()
                .Include(i=>i.department)
                .Include(i=>i.Ins_Subjects).ThenInclude(s => s.Subject)
                .ToListAsync();
        }

        public async Task<Instructor> GetInstructorById(int Id)
        {
            var Instructor =  await _instructorRepositry.GetTableNoTracking()
               .Include(i => i.department)
               .Include(i => i.Ins_Subjects).ThenInclude(s => s.Subject)
               .Where(x=>x.InsId.Equals(Id)).FirstOrDefaultAsync();
            return (Instructor);
        }

        public async Task<Instructor> GetInstructorByIdWithoutInclude(int Id)
        {
            var instructor = await _instructorRepositry.GetByIdAsync(Id);
            return instructor;
        }

        public async Task<decimal> GetTotalSalary()
        {
          return 
                 await _instructorRepositry.GetTotalSalaryForInstructor();
        }
    }

}
