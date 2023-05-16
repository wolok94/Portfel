using AutoMapper;
using Moq;
using Portfel.Application.AutoMapper;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ExpenseFunctions.Query.GetAllExpenses;
using Portfel.Application.UnitTests.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.ExpenseFunctions.Query
{
    public class GetAllExpensesTest
    {
        private readonly IMock<IExpenseRepository> _mockRepository;
        private readonly IMapper _mapper;
        public GetAllExpensesTest()
        {
            _mockRepository = GetExpenseHelper.GetMock();
            var configureProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configureProvider.CreateMapper();
        }

        [Fact]
        public async Task GetAllExpenses_ReturnListOfExpenses()
        {
            var handler = new GetAllExpensesQueryHandler(_mockRepository.Object, _mapper);

            var expenses = await handler.Handle(new GetAllExpensesQuery(), CancellationToken.None);

            expenses.ShouldBeOfType(typeof(List<GetAllExpensesViewModel>));
            expenses.Count.ShouldBe(1);
        }
    }
}
