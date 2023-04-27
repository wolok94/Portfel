using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.UserFunctions.Query
{
    public class GetUserQuery : IRequest<GetUserViewModel>
    {
        public int UserId { get; set; }
    }
}
