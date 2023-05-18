using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ExpenseFunctions.Commands.UpdateExpense;
using Portfel.Application.UnitTests.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.ExpenseFunctions.Commands.UpdateExpense
{
    public class UpdateExpenseTest
    {
        private readonly IMock<IExpenseRepository> _mockRepository;

        public UpdateExpenseTest()
        {
            _mockRepository = GetExpenseHelper.GetMock();  
        }

        [Fact]
        public async Task UpdateExpense_ForValidModel_ChangeExpense()
        {
            var handler = new UpdateExpenseCommandHandler(_mockRepository.Object);

            var response = handler.Handle(new UpdateExpenseCommand { ExpenseId = 1, DateOfPurchase = new DateTime(1994, 12, 05) }, CancellationToken.None);
            var expense = await _mockRepository.Object.GetById(1);

            expense.DateOfPurchase.ShouldBe(new DateTime(1994, 12, 05));

        }
    }
}
