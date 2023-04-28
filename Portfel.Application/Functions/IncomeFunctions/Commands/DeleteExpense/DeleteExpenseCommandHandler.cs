using MediatR;
using Portfel.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Commands.DeleteExpense
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, Unit>
    {
        private readonly IExpenseRepository _expenseRepository;

        public DeleteExpenseCommandHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetById(request.ExpenseId);
            await _expenseRepository.DeleteAsync(expense);
            return Unit.Value;
        }
    }
}
