using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ConnectionWithUserFunctions.Query.GetAllConnectionWithUser
{
    public class GetAllConnectionWithUserViewModel
    {
        public string agreeingUserName { get; set; }
        public int agreeingUserId { get; set; }
        public string invitingUserName { get; set; }
        public int invitingUserId { get; set; }
    }
}
