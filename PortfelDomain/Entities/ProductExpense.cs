using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Domain.Entities
{
    public class ProductExpense
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductAmount { get; set; }
    }
}
