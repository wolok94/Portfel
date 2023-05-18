using MediatR;
using Portfel.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.UserFunctions.Query
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<GetUserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.UserId);
            var mappedUser = new GetUserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Balance = user.Balance,
                Incomes = user.Incomes,
                Expenses = user.Expenses
            };
            return mappedUser;
        }
    }
}
