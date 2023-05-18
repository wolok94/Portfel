using MediatR;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.UserContext;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ConnectionWithUserFunctions.Commands.CreateConnectionWithUser
{
    public class CreateConnectionWithUserCommandHandler : IRequestHandler<CreateConnectionWithUserCommand, int>
    {
        private readonly IConnectionBetweenUsersRepository _connectionWithUser;
        private readonly IUserContext _userContext;

        public CreateConnectionWithUserCommandHandler(IConnectionBetweenUsersRepository connectionWithUser, IUserContext userContext)
        {
            _connectionWithUser = connectionWithUser;
            _userContext = userContext;
        }
        public async Task<int> Handle(CreateConnectionWithUserCommand request, CancellationToken cancellationToken)
        {
            var connection = await _connectionWithUser.AddAsync(new ConnectionBetweenUsers
            {
                AgreeingUserId = request.AgreeingUserId,
                InvitingUserId = _userContext.GetUserId
            });
            return connection.Id;
        }
    }
}
