using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ConnectionWithUserFunctions.Query.GetConnectionWithUserById;
using Portfel.Application.UnitTests.Helper;
using PortfelDomain;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.ConnectionWithUserFunctions.Query
{
    public class GetConnectionWithUserQueryTest
    {
        private readonly IMock<IConnectionWithUserRepository> _mockRepository;

        public GetConnectionWithUserQueryTest()
        {
            _mockRepository = GetConnectionWithUserHelper.GetMock();
        }
        [Fact]
        public async Task GetConnectionWithUser_ForValidId_ReturnsConnectionWithUser()
        {
            var handler = new GetConnectionWithUserByIdQueryHandler(_mockRepository.Object);

            var response = await handler.Handle(new GetConnectionWithUserByIdQuery { ConnectionId = 1}, CancellationToken.None);

            response.ShouldBeOfType(typeof(GetConnectionWithUserByIdViewModel));
        }
    }
}
