using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Filters
{
    public class UpdateUserRoleRequest 
    {
        public int UserId { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
