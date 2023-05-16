using Microsoft.AspNetCore.Identity;
using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.Functions.UserFunctions.Commands.CreateUser;
using Portfel.Application.Functions.UserFunctions.Query;
using Portfel.Application.UnitTests.Helper;
using PortfelDomain;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.UserFunctions.Commands
{
    public class AddUserTest
    {
        private readonly IMock<IUserRepository> _mockRepository;

        public AddUserTest()
        {
            _mockRepository = GetUsersHelper.GetMock();
        }

        [Fact]
        public async Task AddAsync_ForValidModel_ReturnUserId()
        {
            var handler = new CreateUserCommandHandler(_mockRepository.Object, new Mock<IPasswordHasher<User>>().Object);
            var usersBeforeCount = (await _mockRepository.Object.GetAll()).Count;

            var response = await handler.Handle(new CreateUserCommand
            {
                FirstName = "Robert",
                LastName = "Kubica",
                Password = "123456"

            }, CancellationToken.None);

            var allUsers = (await _mockRepository.Object.GetAll()).Count;

            allUsers.ShouldBe(usersBeforeCount + 1);
            response.ShouldBeOfType(typeof(int));
        }
    }
}
