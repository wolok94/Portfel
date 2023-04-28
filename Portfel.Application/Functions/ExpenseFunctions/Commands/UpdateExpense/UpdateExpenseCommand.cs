using MediatR;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ExpenseFunctions.Commands.UpdateExpense
{
    public class UpdateExpenseCommand : IRequest<Unit>
    {
        public int ExpenseId { get; set; }
        public List<Product>? Products { get; set; }
        public DateTime? DateOfPurchase { get; set; }
    }
}
