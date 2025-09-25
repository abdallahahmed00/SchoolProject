using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.View
{
    [Keyless]
    public class ViewDepartment
    {
        public int DID { get; set; }
        public string DName { get; set; }
        public int CountStudent { get; set;  }
    }
}
