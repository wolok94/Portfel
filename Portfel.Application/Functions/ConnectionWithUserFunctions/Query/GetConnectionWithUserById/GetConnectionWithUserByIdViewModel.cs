using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ConnectionWithUserFunctions.Query.GetConnectionWithUserById
{
    public class GetConnectionWithUserByIdViewModel
    {
        public int Id { get; set; }
        public int AgreeingUserId { get; set; }
        public int? InvitingUserId { get; set; }
    }
}
