using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.ConnectionWithUserFunctions.Commands.DeleteConnectionWithUser;
using Portfel.Application.UnitTests.Helper;
using PortfelDomain;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.ConnectionWithUserFunctions.Commands
{
    public class DeleteConnectionWithUserCommandTest
    {
        private readonly IMock<IConnectionBetweenUsersRepository> _mockRepository;

        public DeleteConnectionWithUserCommandTest()
        {
            _mockRepository = GetConnectionWithUserHelper.GetMock();
        }
        [Fact]
        public async Task DeleteConnectionWithUser_ForValidId_ReturnsOneLessConnections()
        {
            var handler = new DeleteConnectionWithUserCommandHandler(_mockRepository.Object);
            var connectionsBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var connection = await _mockRepository.Object.GetById(1);
            await _mockRepository.Object.DeleteAsync(connection);

            var allConnections = (await _mockRepository.Object.GetAll()).Count;
            allConnections.ShouldBe(connectionsBeforeCount - 1);
        }
    }
}
