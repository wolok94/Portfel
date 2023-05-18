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
        public static IMock<IConnectionBetweenUsersRepository> GetMock()
        {
            var mock = new Mock<IConnectionBetweenUsersRepository>();
            var connections = GetConnections();

            mock.Setup(x => x.GetAll()).ReturnsAsync(connections);
            mock.Setup(x => x.AddAsync(It.IsAny<ConnectionBetweenUsers>())).ReturnsAsync((ConnectionBetweenUsers connection) =>
            {
                connections.Add(connection);
                return connection;
            });
            mock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var connection = connections.FirstOrDefault(x => x.Id == id);
                return connection;
            });
            mock.Setup(x => x.DeleteAsync(It.IsAny<ConnectionBetweenUsers>())).Callback((ConnectionBetweenUsers connection) =>
            {
                connections.Remove(connection);
            });

            return mock;
        }

        private static List<ConnectionBetweenUsers> GetConnections()
        {
            return new List<ConnectionBetweenUsers>
            {
                new ConnectionBetweenUsers
                {
                    AgreeingUserId = 1,
                    Id = 1,
                    InvitingUserId = 2,
                },
                new ConnectionBetweenUsers
                {
                    Id = 2,
                    AgreeingUserId = 3,
                    InvitingUserId = 2
                }
            };
        }
    }
}
