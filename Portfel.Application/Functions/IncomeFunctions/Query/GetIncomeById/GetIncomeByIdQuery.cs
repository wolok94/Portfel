using MediatR;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Query.GetIncomeById
{
    public class GetIncomeByIdQuery : IRequest<Income>
    {
        public int IncomeId { get; set; }
    }
}
