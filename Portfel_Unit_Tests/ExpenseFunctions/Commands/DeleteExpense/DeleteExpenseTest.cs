using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ExpenseFunctions.Commands.DeleteExpense;
using Portfel.Application.UnitTests.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.ExpenseFunctions.Commands.DeleteExpense
{
    public class DeleteExpenseTest
    {
        private readonly IMock<IExpenseRepository> _mockRepository;

        public DeleteExpenseTest()
        {
            _mockRepository = GetExpenseHelper.GetMock();
        }
        [Fact]
        public async Task DeleteExpense_ForValidId_ReturnOneLessAmountOfExpenses()
        {
            var handler = new DeleteExpenseCommandHandler(_mockRepository.Object);
            var expensesBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var response = await handler.Handle(new DeleteExpenseCommand { ExpenseId = 1 }, CancellationToken.None);
            var allExpenses = (await _mockRepository.Object.GetAll()).Count;

            allExpenses.ShouldBe(expensesBeforeCount - 1);

        }
    }
}
