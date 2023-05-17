using MediatR;
using Moq;
using Portfel.Application.Contracts.Persistance;
using Portfel.Application.UserContext;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.IncomeFunctions.Commands.CreateIncome
{
    public class CreateIncomeCommandHandler : IRequestHandler<CreateIncomeCommand, int>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IUserContext _userContext;

        public CreateIncomeCommandHandler(IIncomeRepository incomeRepository, IUserContext userContext)
        {
            _incomeRepository = incomeRepository;
            _userContext = userContext;
        }
        public async Task<int> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = await _incomeRepository.AddAsync(new Income
            {
                incomeDate = DateTime.Now,
                nameOfIncome = request.nameOfIncome,
                sumOfIncome = request.sumOfIncome,
                UserId = _userContext.GetUserId
            });

            return income.Id;
        }
    }
}
