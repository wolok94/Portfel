using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.UserFunctions.Query;
using Portfel.Application.UnitTests.Helper;
using PortfelDomain;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.UserFunctions.Query
{
    public class GetUserByIdTest
    {
        private readonly IMock<IUserRepository> _mockRepository;

        public GetUserByIdTest()
        {
            _mockRepository = GetUsersHelper.GetMock();
        }
        [Fact]
        public async Task GetUserById_ForValidId_ReturnsUser()
        {
            var handler = new GetUserQueryHandler(_mockRepository.Object);

            var response = await handler.Handle(new GetUserQuery { UserId = 2 }, CancellationToken.None);

            response.FirstName.ShouldBe("Stefan");
            response.LastName.ShouldBe("Kowalski");
            response.ShouldBeOfType(typeof(GetUserViewModel));
        }
    }
}
