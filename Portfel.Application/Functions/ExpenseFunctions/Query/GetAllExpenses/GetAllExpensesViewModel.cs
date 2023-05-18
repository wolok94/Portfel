using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ExpenseFunctions.Query.GetAllExpenses
{
    public class GetAllExpensesViewModel
    {
        public List<Product> Products { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public double Sum { get; set; }
    }
}
