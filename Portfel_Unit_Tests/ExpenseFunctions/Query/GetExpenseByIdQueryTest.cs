using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ExpenseFunctions.Query.GetExpenseById;
using Portfel.Application.UnitTests.Helper;
using PortfelDomain;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.ExpenseFunctions.Query
{
    public class GetExpenseByIdQueryTest
    {
        private readonly IMock<IExpenseRepository> _mockRepository;

        public GetExpenseByIdQueryTest()
        {
            _mockRepository = GetExpenseHelper.GetMock();
        }
        [Fact]
        public async Task GetExpenseById_ForValidId_ReturnExpense()
        {
            var handler = new GetExpernseByIdQueryHandler(_mockRepository.Object);

            var response = await handler.Handle(new GetExpenseByIdQuery { ExpenseId = 1}, CancellationToken.None);

            response.ShouldBeOfType(typeof(Expense));
        }
    }
}
