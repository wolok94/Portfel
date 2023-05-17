using MediatR;
using Portfel.Application.Contracts.Persistance;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Query.GetIncomeById
{
    public class GetIncomeByIdQueryHandler : IRequestHandler<GetIncomeByIdQuery, Income>
    {
        private readonly IIncomeRepository _incomeRepository;

        public GetIncomeByIdQueryHandler(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }
        public Task<Income> Handle(GetIncomeByIdQuery request, CancellationToken cancellationToken)
        {
            var income = _incomeRepository.GetById(request.)
        }
    }
}
