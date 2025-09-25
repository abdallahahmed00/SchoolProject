using Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface.View
{
    public interface IViewRepository<T> :IGenericRepositoryAsync<T>where T:class
    {
    }
}
