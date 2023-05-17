using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfelDomain
{
    public class ConnectionWithUser
    {
        public int Id { get; set; }
        public int? InvitingUserId { get; set; }
        public User InvitingUser { get; set; }
        public int AgreeingUserId { get; set; }
        public User User { get; set; }
    }
}
