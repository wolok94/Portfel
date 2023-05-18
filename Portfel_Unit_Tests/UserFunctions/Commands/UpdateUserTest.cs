using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.UserFunctions.Commands.UpdateUser;
using Portfel.Application.UnitTests.Helper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.UserFunctions.Commands
{
    public class UpdateUserTest
    {
        private readonly IMock<IUserRepository> _mockRepository;

        public UpdateUserTest()
        {
            _mockRepository = GetUsersHelper.GetMock();
        }

        [Fact]
        public async Task UpdateUser_ForValidUser_ReturnUpdatedUser()
        {
            var handler = new UpdateUserCommandHandler(_mockRepository.Object);

            var response = await handler.Handle(new UpdateUserCommand
            {
                Id = 1,
                FirstName = "Karol"
            }, CancellationToken.None);

            var user = await _mockRepository.Object.GetById(1);
            user.FirstName.ShouldBe("Karol");
        }
    }
}
