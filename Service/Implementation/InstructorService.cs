using Infrastructure.Interface;
using Infrastructure.Repositires;
using Microsoft.AspNetCore.Http;
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
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public InstructorService(IInstructorRepositry instructorRepositry, IFileService fileService,
            IHttpContextAccessor httpContextAccessor) 
        
        {
            _instructorRepositry = instructorRepositry; 
            _fileService= fileService;
            _httpContextAccessor= httpContextAccessor;
        }

        public async Task<string> AddInstructorAsync(Instructor instructor, IFormFile formFile)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var url =context.Scheme+"://"+context.Host;
            var image =await _fileService.UploadImage("Instructors", formFile);
            instructor.Image = url+image;
            var result =await _instructorRepositry.AddAsync(instructor);
            return "Success";
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
        public async Task<string> UpdateInstructorImageAsync( int Id, IFormFile formFile)
        {
            var instructor =await _instructorRepositry.GetByIdAsync(Id);
            if (instructor == null)
            {
                return "InstructorNotFound";
            }
            var context = _httpContextAccessor.HttpContext.Request;
            var url = context.Scheme + "://" + context.Host;
            var image = await _fileService.UploadImage("Instructors", formFile);
            instructor.Image = url + image;
            await _instructorRepositry.UpdateAsync(instructor);
            await _instructorRepositry.SaveChangesAsync();
            return "Success";
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

        public async Task<bool> IsNameExist(string Name)
        {
            var result = await _instructorRepositry.GetTableNoTracking()
                .Where(x => x.Name.Equals(Name)).FirstOrDefaultAsync();
            if (result==null)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> IsNameExistById(int Id)
        {
            var result = await _instructorRepositry.GetTableNoTracking()
                .Where(x => x.InsId.Equals(Id)).FirstOrDefaultAsync();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string Name, int Id)
        {

            var result = await _instructorRepositry.GetTableNoTracking()
                .Where(x => x.Name.Equals(Name)&x.InsId!=Id).FirstOrDefaultAsync();
            if (result == null)
            {
                return false;
            }
            return true;
        }

       
    }

}
