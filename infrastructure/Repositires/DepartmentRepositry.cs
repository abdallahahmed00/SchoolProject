using Data.Entities;
using infrastructure.Data;
using Infrastructure.InfrastructureBase;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositires
{
    public class DepartmentRepositry : GenericRepositoryAsync<Department> , IDepartmentRepositry
    {
        private readonly DbSet<Department> _Department;
        public DepartmentRepositry(AppDbContext context) : base(context)
        {
            _Department = context.Set<Department>();
        }

    }
}
