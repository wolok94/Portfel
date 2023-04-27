using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PortfelDomain
{
    public class Expense
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public double Sum { get; set; }

        public Expense()
        {
            Sum = Products.Sum(x => x.Amount * x.Price);
        }

    }
}
