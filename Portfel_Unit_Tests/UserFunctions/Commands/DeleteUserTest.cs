using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.UserFunctions.Commands.DeleteUser;
using Portfel.Application.UnitTests.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.UserFunctions.Commands
{
    public class DeleteUserTest
    {
        private readonly IMock<IUserRepository> _mockRepository;

        public DeleteUserTest()
        {
            _mockRepository = GetUsersHelper.GetMock();
        }

        [Fact]
        public async Task DeleteUser_ForValidId_OneLessUser()
        {
            var handler = new DeleteUserCommandHandler(_mockRepository.Object);
            var usersBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var response = await handler.Handle(new DeleteUserCommand { UserId = 1 }, CancellationToken.None);

            var allUsers = (await _mockRepository.Object.GetAll()).Count;
            allUsers.ShouldBe(usersBeforeCount - 1);

        }
    }
}
