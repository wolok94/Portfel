using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PortfelDomain
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public List<User> users { get; set; }
        public List<Product> ProductList { get; set; }

    }
}
