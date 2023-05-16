using Moq;
using Portfel.Application.Contracts.Persistance;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.UnitTests.Helper
{
    public class GetUsersHelper
    {
        public static IMock<IUserRepository> GetMock()
        {
            var mock = new Mock<IUserRepository>();
            var users = GetUsers();

            mock.Setup(x => x.AddAsync(It.IsAny<User>())).ReturnsAsync((User user) =>
            {
                users.Add(user);
                return user;
            });

            mock.Setup(x => x.GetAll()).ReturnsAsync(users);

            return mock;
        }

        private static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski"
                },                new User
                {
                    Id = 2,
                    FirstName = "Stefan",
                    LastName = "Kowalski"
                }
            };
            
        }
    }
}
