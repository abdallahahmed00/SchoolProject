using Data.Entities;
using Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Data
{ 
    public class AppDbContext : IdentityDbContext<User ,Role,  int, IdentityUserClaim<int>, 
        IdentityUserRole<int>, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        //public AppDbContext()     
        //{

        //}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> User { get; set;}
        public DbSet<Student>Students { get; set; } 
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Ins_Subject> Ins_Subjects { get; set; }
        public DbSet<UserRefreshToken> userRefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         //   modelBuilder.HasDefaultSchema("School");
            base.OnModelCreating(modelBuilder);
        }

    }
}
