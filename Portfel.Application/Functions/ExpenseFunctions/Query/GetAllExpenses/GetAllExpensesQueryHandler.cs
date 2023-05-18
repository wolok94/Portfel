using AutoMapper;
using MediatR;
using Portfel.Application.Contracts.Persistance;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.ExpenseFunctions.Query.GetAllExpenses
{
    public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, List<GetAllExpensesViewModel>>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public GetAllExpensesQueryHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllExpensesViewModel>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetAll();
            return _mapper.Map<List<GetAllExpensesViewModel>>(expenses);
            
        }
    }
}
