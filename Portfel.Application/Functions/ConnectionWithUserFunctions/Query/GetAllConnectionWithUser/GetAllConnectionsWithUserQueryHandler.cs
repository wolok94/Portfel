using AutoMapper;
using MediatR;
using Portfel.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ConnectionWithUserFunctions.Query.GetAllConnectionWithUser
{
    public class GetAllConnectionsWithUserQueryHandler : IRequestHandler<GetAllConnectionsWithUserQuery, List<GetAllConnectionWithUserViewModel>>
    {
        private readonly IConnectionWithUserRepository _connectionWithUserRepository;
        private readonly IMapper _mapper;

        public GetAllConnectionsWithUserQueryHandler(IConnectionWithUserRepository connectionWithUserRepository, IMapper mapper)
        {
            _connectionWithUserRepository = connectionWithUserRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllConnectionWithUserViewModel>> Handle(GetAllConnectionsWithUserQuery request, CancellationToken cancellationToken)
        {
            var connections = await _connectionWithUserRepository.GetAll();
            return _mapper.Map<List<GetAllConnectionWithUserViewModel>>(connections);
        }
    }
}
