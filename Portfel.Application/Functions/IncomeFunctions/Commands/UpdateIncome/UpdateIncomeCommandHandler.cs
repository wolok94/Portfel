using MediatR;
using Portfel.Application.Contracts.Persistance;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Commands.UpdateIncome
{
    public class UpdateIncomeCommandHandler : IRequestHandler<UpdateIncomeCommand, Unit>
    {
        private readonly IIncomeRepository _incomeRepository;

        public UpdateIncomeCommandHandler(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }
        public async Task<Unit> Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
        {
            var incomeToUpdate = await _incomeRepository.GetById(request.Id);
            var modifiedIncome = GetModifiedIncomes(request, incomeToUpdate);

            await _incomeRepository.UpdateAsync(modifiedIncome);
            return Unit.Value;
        }
        private Income GetModifiedIncomes(UpdateIncomeCommand request, Income income)
        {
            foreach(var requestProperties in request.GetType().GetProperties())
            {
                if (requestProperties.GetValue(request) != null)
                {
                    foreach(var incomeProperties in income.GetType().GetProperties())
                    {
                        if (requestProperties.Name == incomeProperties.Name)
                        {
                            incomeProperties.SetValue(income, requestProperties.GetValue(request));
                        }
                    }
                }
            }
            return income;
        }
    }
}
