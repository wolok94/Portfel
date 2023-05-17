using MediatR;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ExpenseFunctions.Query.GetExpenseById
{
    public class GetExpenseByIdQuery : IRequest<Expense>
    {
        public int ExpenseId { get; set; }
    }
}
