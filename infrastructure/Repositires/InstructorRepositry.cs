using Data.Entities;
using infrastructure.Data;
using Infrastructure.InfrastructureBase;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositires
{
    public class InstructorRepositry : GenericRepositoryAsync<Instructor>, IInstructorRepositry
    {
        private readonly DbSet<Instructor> instructor;
        public InstructorRepositry(AppDbContext context) : base(context)
        {
            instructor = context.Set<Instructor>();
        }

        public async Task<decimal> GetTotalSalaryForInstructor()
        {
            return await instructor.Where(x=>x.Salary.HasValue).SumAsync(x => x.Salary??0);
        }
    }
}
