using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Domain.Entities
{
    public class ShoppingProduct : Product
    {
        public bool isTaken { get; set; } = false;
    }
}
