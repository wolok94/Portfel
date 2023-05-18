using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ExpenseFunctions.Commands.CreateExpense;
using Portfel.Application.UnitTests.Helper;
using Portfel.Application.UserContext;
using PortfelDomain;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.ExpenseFunctions.Commands.CreateExpense
{
    public class CreateExpenseTest
    {
        private readonly IMock<IExpenseRepository> _mockRepository;
        public CreateExpenseTest()
        {
            _mockRepository = GetExpenseHelper.GetMock();
        }
        [Fact]
        public async Task AddAsync_ForValidModel_ReturnCreatedExpense()
        {

            var handler = new CreateExpenseCommandHandler(_mockRepository.Object, new Mock<IUserContext>().Object);
            var expensesBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var expense = new CreateExpenseCommand()
            {
                DateOfPurchase = DateTime.Now,
                Products = new List<Product>()
                {
                    new Product
                    {
                        Id = 2,
                        Name = "Test1",
                        Price = 150,

                    }
                }
            };
            var response = await handler.Handle(expense, CancellationToken.None);
            var allExpenses = (await _mockRepository.Object.GetAll()).Count;

            allExpenses.ShouldBe(expensesBeforeCount + 1);
            response.ShouldBeOfType(typeof(int));

        }
    }
}
