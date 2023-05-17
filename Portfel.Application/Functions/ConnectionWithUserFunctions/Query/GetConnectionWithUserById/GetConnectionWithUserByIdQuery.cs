using MediatR;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ConnectionWithUserFunctions.Query.GetConnectionWithUserById
{
    public class GetConnectionWithUserByIdQuery : IRequest<GetConnectionWithUserByIdViewModel>
    {
        public int ConnectionId { get; set; }
    }
}
