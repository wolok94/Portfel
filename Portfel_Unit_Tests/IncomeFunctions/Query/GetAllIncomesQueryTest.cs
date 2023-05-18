using AutoMapper;
using Moq;
using Portfel.Application.AutoMapper;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ExpenseFunctions.Query.GetAllExpenses;
using Portfel.Application.Functions.IncomeFunctions.Query.GetAllIncomes;
using Portfel.Application.UnitTests.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.IncomeFunctions.Query
{
    public class GetAllIncomesQueryTest
    {
        private readonly IMock<IIncomeRepository> _mockRepository;
        private readonly IMapper _mapper;

        public GetAllIncomesQueryTest()
        {
            _mockRepository = GetIncomeHelper.GetMock();
            var configureProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configureProvider.CreateMapper();
        }
        [Fact]
        public async Task GetAllIncomes_ReturnsAllIncomes()
        {
            var handler = new GetAllIncomesQueryHandler(_mockRepository.Object, _mapper);

            var response = await handler.Handle(new GetAllIncomesQuery(), CancellationToken.None);

            response.ShouldBeOfType(typeof(List<GetAllIncomesViewModel>));
        }
    }
}
