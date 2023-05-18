using MediatR;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.UserContext;
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
        private readonly IUserContext _userContext;

        public CreateExpenseCommandHandler(IExpenseRepository expenseRepository, IUserContext userContext)
        {
            _expenseRepository = expenseRepository;
            _userContext = userContext;
        }
        public async Task<int> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.AddAsync(new Expense
            {
                Products = request.Products,
                DateOfPurchase = request.DateOfPurchase,
                UserId = _userContext.GetUserId
            });
            return expense.Id;
        }
    }
}
