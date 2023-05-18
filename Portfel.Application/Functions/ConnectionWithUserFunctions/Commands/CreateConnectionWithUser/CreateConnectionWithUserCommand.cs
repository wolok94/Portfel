using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ConnectionWithUserFunctions.Commands.CreateConnectionWithUser
{
    public class CreateConnectionWithUserCommand : IRequest<int>
    {
        public int AgreeingUserId { get; set; }
    }
}
