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
    public class GetConnectionWithUserHelper
    {
        public static IMock<IConnectionWithUserRepository> GetMock()
        {
            var mock = new Mock<IConnectionWithUserRepository>();
            var connections = GetConnections();

            mock.Setup(x => x.GetAll()).ReturnsAsync(connections);
            mock.Setup(x => x.AddAsync(It.IsAny<ConnectionWithUser>())).ReturnsAsync((ConnectionWithUser connection) =>
            {
                connections.Add(connection);
                return connection;
            });
            mock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var connection = connections.FirstOrDefault(x => x.Id == id);
                return connection;
            });
            mock.Setup(x => x.DeleteAsync(It.IsAny<ConnectionWithUser>())).Callback((ConnectionWithUser connection) =>
            {
                connections.Remove(connection);
            });

            return mock;
        }

        private static List<ConnectionWithUser> GetConnections()
        {
            return new List<ConnectionWithUser>
            {
                new ConnectionWithUser
                {
                    AgreeingUserId = 1,
                    Id = 1,
                    InvitingUserId = 2,
                },
                new ConnectionWithUser
                {
                    Id = 2,
                    AgreeingUserId = 3,
                    InvitingUserId = 2
                }
            };
        }
    }
}
