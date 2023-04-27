using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfelDomain
{
    public class SavingGoal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string nameOfSavingGoal { get; set; }
        public double amountToSave { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Installment { get; set; }

        public SavingGoal()
        {
            TimeSpan timeSpan = EndDate - StartDate;
            int numberOfPayments = (int)Math.Ceiling(timeSpan.TotalDays / 30);
            this.Installment = amountToSave / numberOfPayments;
        }
    }
}
