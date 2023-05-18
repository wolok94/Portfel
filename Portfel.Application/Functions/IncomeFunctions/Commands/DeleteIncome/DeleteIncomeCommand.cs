using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Commands.DeleteIncome
{
    public class DeleteIncomeCommand : IRequest<Unit>
    {
        public int IncomeId { get; set; }
    }
}
