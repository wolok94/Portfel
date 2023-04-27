using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Contracts.Persistance
{
    public interface IIncome : IAsyncRepository<Income>
    {
    }
}
