using AutoMapper;
using MediatR;
using Portfel.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Query.GetAllIncomes
{
    public class GetAllIncomesQueryHandler : IRequestHandler<GetAllIncomesQuery, List<GetAllIncomesViewModel>>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;

        public GetAllIncomesQueryHandler(IIncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllIncomesViewModel>> Handle(GetAllIncomesQuery request, CancellationToken cancellationToken)
        {
            var incomes = await _incomeRepository.GetAll();
            var mappedIncomes = _mapper.Map<List<GetAllIncomesViewModel>>(incomes);
            return mappedIncomes;
        }
    }
}
