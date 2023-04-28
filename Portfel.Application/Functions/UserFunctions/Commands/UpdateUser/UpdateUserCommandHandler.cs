using MediatR;
using Portfel.Application.Contracts.Persistance;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.UserFunctions.Commands.UpdateUser
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);
            var modifiedUser = GetModifiedUser(request, user);
            await _userRepository.UpdateAsync(modifiedUser);
            return Unit.Value;

        }

        public User GetModifiedUser(UpdateUserCommand request, User user)
        {

            foreach (var requestPropertyInfo in request.GetType().GetProperties())
            {
                if (requestPropertyInfo != null)
                {
                    foreach (var userPropertyInfo in user.GetType().GetProperties())
                    {
                        if (requestPropertyInfo.Name == userPropertyInfo.Name)
                        {
                            userPropertyInfo.SetValue(user, requestPropertyInfo);
                            break;
                        }
                    }
                }
            }
            return user;

        }
    }
}
