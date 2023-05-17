using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Commands.UpdateIncome
{
    public class UpdateIncomeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string nameOfIncome { get; set; }
        public double sumOfIncome { get; set; }
        public DateTime incomeDate { get; set; }
    }
}
