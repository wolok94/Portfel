using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ConnectionWithUserFunctions.Commands.DeleteConnectionWithUser
{
    public class DeleteConnectionWithUserCommand : IRequest<Unit>
    {
        public int ConnectionId { get; set; }
    }
}
