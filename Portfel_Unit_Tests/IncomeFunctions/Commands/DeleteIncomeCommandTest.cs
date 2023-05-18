using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.IncomeFunctions.Commands.DeleteIncome;
using Portfel.Application.UnitTests.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.IncomeFunctions.Commands
{
    public class DeleteIncomeCommandTest
    {
        private readonly IMock<IIncomeRepository> _mockRepository;

        public DeleteIncomeCommandTest()
        {
            _mockRepository = GetIncomeHelper.GetMock();
        }
        [Fact]
        public async Task DeleteIncome_ForValidId_ReturnsOneLessListOfIncomes()
        {
            var handler = new DeleteIncomeCommandHandler(_mockRepository.Object);
            var incomesBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            await handler.Handle(new DeleteIncomeCommand { IncomeId = 1 }, CancellationToken.None);

            var allIncomes = (await _mockRepository.Object.GetAll()).Count;

            allIncomes.ShouldBe(incomesBeforeCount - 1);

        }
    }
}
