using AutoMapper;
using Moq;
using Portfel.Application.AutoMapper;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ConnectionWithUserFunctions.Query.GetAllConnectionWithUser;
using Portfel.Application.UnitTests.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.ConnectionWithUserFunctions.Query
{
    public class GetAllConnectionWithUserQueryTest
    {
        private readonly IMock<IConnectionBetweenUsersRepository> _mockRepository;
        private readonly IMapper _mapper;

        public GetAllConnectionWithUserQueryTest()
        {
            _mockRepository = GetConnectionWithUserHelper.GetMock();
            var configureProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configureProvider.CreateMapper();
        }

        [Fact]
        public async Task GetAllConnectionWithUser_ReturnsListOfConnection()
        {
            var handler = new GetAllConnectionsWithUserQueryHandler(_mockRepository.Object, _mapper);

            var response = await handler.Handle(new GetAllConnectionsWithUserQuery(), CancellationToken.None);

            response.ShouldBeOfType(typeof(List<GetAllConnectionWithUserViewModel>));
        }


    }
}
