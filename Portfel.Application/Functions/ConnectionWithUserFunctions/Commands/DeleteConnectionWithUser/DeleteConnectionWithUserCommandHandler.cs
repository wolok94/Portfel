using MediatR;
using Portfel.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ConnectionWithUserFunctions.Commands.DeleteConnectionWithUser
{
    public class DeleteConnectionWithUserCommandHandler : IRequestHandler<DeleteConnectionWithUserCommand, Unit>
    {
        private readonly IConnectionBetweenUsersRepository _connectionWithUserRepository;

        public DeleteConnectionWithUserCommandHandler(IConnectionBetweenUsersRepository connectionWithUserRepository)
        {
            _connectionWithUserRepository = connectionWithUserRepository;
        }
        public async Task<Unit> Handle(DeleteConnectionWithUserCommand request, CancellationToken cancellationToken)
        {
            var connection = await _connectionWithUserRepository.GetById(request.ConnectionId);
            await _connectionWithUserRepository.DeleteAsync(connection);
            return Unit.Value;
        }
    }
}
