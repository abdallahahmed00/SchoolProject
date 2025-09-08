using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.User.Queries.Results
{
    public class GetListUserResponse
    {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string? Country { get; set; }
            public string? Address { get; set; }

    }
}
