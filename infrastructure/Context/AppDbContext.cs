using Data.Entities;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Data
{
    public class AppDbContext :DbContext
    {
        //public AppDbContext()
        //{

        //}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student>Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Ins_Subject> Ins_Subjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         //   modelBuilder.HasDefaultSchema("School");
            base.OnModelCreating(modelBuilder);
        }

    }
}
