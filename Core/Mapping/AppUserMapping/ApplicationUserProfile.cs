using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.AppUserMapping
{
    public partial class ApplicationUserProfile :Profile
    {
        public ApplicationUserProfile() 
        {
            AddUserMapping();
        }
    }
}
