using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.IncomeFunctions.Query.GetIncomeById;
using Portfel.Application.UnitTests.Helper;
using PortfelDomain;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.IncomeFunctions.Query
{
    public class GetIncomeByIdQueryTest
    {
        private readonly IMock<IIncomeRepository> _mockRepository;

        public GetIncomeByIdQueryTest()
        {
            _mockRepository = GetIncomeHelper.GetMock();
        }
        [Fact]
        public async Task GetIncomeById_ForValidId_ReturnIncome()
        {
            var handler = new GetIncomeByIdQueryHandler(_mockRepository.Object);

            var response = await handler.Handle(new GetIncomeByIdQuery { IncomeId = 1 }, CancellationToken.None);

            response.ShouldBeOfType(typeof(Income));
            response.nameOfIncome.ShouldBe("Wypłata");
        }
    }
}
