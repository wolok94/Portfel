using MediatR;
using Portfel.Application.Contracts.Persistance;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ExpenseFunctions.Commands.UpdateExpense
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Unit>
    {
        private readonly IExpenseRepository _expenseRepository;

        public UpdateExpenseCommandHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task<Unit> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetById(request.ExpenseId);
            var modifiedExpense = GetModifiedExpense(request, expense);
            await _expenseRepository.UpdateAsync(modifiedExpense);
            return Unit.Value;
        }
        private Expense GetModifiedExpense(UpdateExpenseCommand request, Expense expense)
        {
            foreach(var requestProperty in request.GetType().GetProperties())
            {
                if (requestProperty.GetValue(request) != null)
                {
                    foreach(var expenseProperty in expense.GetType().GetProperties())
                    {
                        if (requestProperty.Name == expenseProperty.Name)
                        {
                            expenseProperty.SetValue(expense, requestProperty.GetValue(request));
                        }
                    }
                }
            }
            return expense;
        }
    }
}
