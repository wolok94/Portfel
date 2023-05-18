using MediatR;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Commands.CreateIncome
{
    public class CreateIncomeCommand : IRequest<int>
    {
        public int? UserId { get; set; }
        public string nameOfIncome { get; set; }
        public double sumOfIncome { get; set; }

    }
}
