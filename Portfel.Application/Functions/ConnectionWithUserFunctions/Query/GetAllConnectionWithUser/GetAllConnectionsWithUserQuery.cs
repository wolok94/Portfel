using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ConnectionWithUserFunctions.Query.GetAllConnectionWithUser
{
    public class GetAllConnectionsWithUserQuery : IRequest<List<GetAllConnectionWithUserViewModel>>
    {
    }
}
