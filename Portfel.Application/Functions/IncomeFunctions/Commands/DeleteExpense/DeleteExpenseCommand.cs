using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Commands.DeleteExpense
{
    public class DeleteExpenseCommand : IRequest<Unit>
    {
        public int ExpenseId { get; set; }
    }
}
