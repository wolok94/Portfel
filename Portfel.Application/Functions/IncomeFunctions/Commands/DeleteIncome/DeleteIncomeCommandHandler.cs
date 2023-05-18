using MediatR;
using Portfel.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Commands.DeleteIncome
{
    public class DeleteIncomeCommandHandler : IRequestHandler<DeleteIncomeCommand, Unit>
    {
        private readonly IIncomeRepository _incomeRepository;

        public DeleteIncomeCommandHandler(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }
        public async Task<Unit> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = await _incomeRepository.GetById(request.IncomeId);
            await _incomeRepository.DeleteAsync(income);
            return Unit.Value;
        }
    }
}
