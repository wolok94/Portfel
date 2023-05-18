using MediatR;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ExpenseFunctions.Query.GetAllExpenses
{
    public class GetAllExpensesQuery : IRequest<List<GetAllExpensesViewModel>>
    {

    }
}
