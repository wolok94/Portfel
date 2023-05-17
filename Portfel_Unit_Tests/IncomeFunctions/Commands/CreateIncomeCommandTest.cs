using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.IncomeFunctions.Commands.CreateIncome;
using Portfel.Application.UnitTests.Helper;
using Portfel.Application.UserContext;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.IncomeFunctions.Commands
{
    public class CreateIncomeCommandTest
    {
        private readonly IMock<IIncomeRepository> _mockRepository;

        public CreateIncomeCommandTest()
        {
            _mockRepository = GetIncomeHelper.GetMock();
        }
        [Fact]
        public async Task CreateIncome_ForValidModel_ReturnId()
        {
            var handler = new CreateIncomeCommandHandler(_mockRepository.Object, new Mock<IUserContext>().Object);
            var incomesBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var response = await handler.Handle(new CreateIncomeCommand
            {
                
                nameOfIncome = "Lewizna",
                sumOfIncome = 2000
            }, CancellationToken.None);

            var allIncomes = (await _mockRepository.Object.GetAll()).Count;

            allIncomes.ShouldBe(incomesBeforeCount + 1);
            response.ShouldBeOfType(typeof(int));
        }
    }
}
