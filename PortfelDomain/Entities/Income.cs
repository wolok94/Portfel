using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfelDomain
{
    public class Income
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public string nameOfIncome { get; set; }
        public double sumOfIncome { get; set; }
        public DateTime incomeDate { get; set; }
    }
}
