using MediatR;
using Portfel.Application.Contracts.Persistance;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ExpenseFunctions.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, int>
    {
        private readonly IExpenseRepository _expenseRepository;

        public CreateExpenseCommandHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task<int> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.AddAsync(new Expense
            {
                Products = request.Products,
                DateOfPurchase = request.DateOfPurchase
            });
            return expense.Id;
        }
    }
}
