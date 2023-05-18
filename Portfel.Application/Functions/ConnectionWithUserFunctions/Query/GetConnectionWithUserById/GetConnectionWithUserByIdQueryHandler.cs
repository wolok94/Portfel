using MediatR;
using Portfel.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ConnectionWithUserFunctions.Query.GetConnectionWithUserById
{
    public class GetConnectionWithUserByIdQueryHandler : IRequestHandler<GetConnectionWithUserByIdQuery, GetConnectionWithUserByIdViewModel>
    {
        private readonly IConnectionBetweenUsersRepository _connectionWithUserRepository;

        public GetConnectionWithUserByIdQueryHandler(IConnectionBetweenUsersRepository connectionWithUserRepository)
        {
            _connectionWithUserRepository = connectionWithUserRepository;
        }

        public async Task<GetConnectionWithUserByIdViewModel> Handle(GetConnectionWithUserByIdQuery request, CancellationToken cancellationToken)
        {
            var connection = await _connectionWithUserRepository.GetById(request.ConnectionId);
            return new GetConnectionWithUserByIdViewModel
            {
                AgreeingUserId = connection.AgreeingUserId,
                InvitingUserId = connection.InvitingUserId,
                Id = connection.Id,
            };
        }

 
    }
}
