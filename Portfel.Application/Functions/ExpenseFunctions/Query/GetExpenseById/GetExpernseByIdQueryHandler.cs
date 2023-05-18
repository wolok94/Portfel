using MediatR;
using Portfel.Application.Contracts.Persistance;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ExpenseFunctions.Query.GetExpenseById
{
    public class GetExpernseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, Expense>
    {
        private readonly IExpenseRepository _expenseRepository;

        public GetExpernseByIdQueryHandler(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task<Expense> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetById(request.ExpenseId);
            return expense;
        }
    }
}
