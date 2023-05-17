using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ConnectionWithUserFunctions.Commands;
using Portfel.Application.Functions.ConnectionWithUserFunctions.Commands.CreateConnectionWithUser;
using Portfel.Application.UnitTests.Helper;
using Portfel.Application.UserContext;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.ConnectionWithUserFunctions.Commands
{
    public class CreateConnectionWithUserCommandTest
    {
        private readonly IMock<IConnectionWithUserRepository> _mockRepository;

        public CreateConnectionWithUserCommandTest()
        {
            _mockRepository = GetConnectionWithUserHelper.GetMock();
        }
        [Fact]
        public async Task CreateConnectionWithUser_ForValidModel_ReturnConnection()
        {
            var handler = new CreateConnectionWithUserCommandHandler(_mockRepository.Object, new Mock<IUserContext>().Object);
            var connectionsBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var response = await handler.Handle(new CreateConnectionWithUserCommand { AgreeingUserId = 4 }, CancellationToken.None);
            var allConnections = (await _mockRepository.Object.GetAll()).Count;

            allConnections.ShouldBe(connectionsBeforeCount + 1);
            allConnections.ShouldBeOfType(typeof(int));

        }
    }
}
