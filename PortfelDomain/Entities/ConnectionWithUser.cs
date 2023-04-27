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
        public int InvitedUserId { get; set; }
        public User InvitedUser { get; set; }
        public int AgreeingUserId { get; set; }
        public User User { get; set; }
    }
}
