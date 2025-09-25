using Data.Entities;
using Data.Entities.View;
using infrastructure.Data;
using Infrastructure.InfrastructureBase;
using Infrastructure.Interface.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositires.View
{
    public class ViewDepartmentRepositry : GenericRepositoryAsync<ViewDepartment>,IViewRepository<ViewDepartment>
    {
        private DbSet<ViewDepartment> _ViewDepartment;
        public ViewDepartmentRepositry(AppDbContext context) :base(context)
        {
            _ViewDepartment = context.Set<ViewDepartment>();
        }

    }
}
