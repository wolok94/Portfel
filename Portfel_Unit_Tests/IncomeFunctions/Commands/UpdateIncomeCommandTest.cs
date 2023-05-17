using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.IncomeFunctions.Commands.UpdateIncome;
using Portfel.Application.UnitTests.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.IncomeFunctions.Commands
{
    public class UpdateIncomeCommandTest
    {
        private readonly IMock<IIncomeRepository> _mockRepository;

        public UpdateIncomeCommandTest()
        {
            _mockRepository = GetIncomeHelper.GetMock();
        }
        [Fact]
        public async Task UpdateIncome_ForValidModel_ChangeIncome()
        {
            var handler = new UpdateIncomeCommandHandler(_mockRepository.Object);

            await handler.Handle(new UpdateIncomeCommand { Id = 1, nameOfIncome = "Darowizna" }, CancellationToken.None);

            var income = await _mockRepository.Object.GetById(1);
            income.nameOfIncome.ShouldBe("Darowizna");

        }
    }
}
