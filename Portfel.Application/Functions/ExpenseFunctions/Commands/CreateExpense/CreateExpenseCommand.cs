using MediatR;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ExpenseFunctions.Commands.CreateExpense
{
    public class CreateExpenseCommand : IRequest<int>
    {
        public List<Product> Products { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
