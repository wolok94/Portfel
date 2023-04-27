using MediatR;
using Microsoft.AspNetCore.Identity;
using Portfel.Application.Contracts.Persistance;
using PortfelDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.Application.Functions.UserFunctions.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.AddAsync(new User
            {
                NickName = request.NickName
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,

            });
            user.EncryptedPassword = GetHashedPassword(user, request.Password);
            return user.Id;
        }
        private string GetHashedPassword(User user, string password)
        {
            var hashedPassword = _passwordHasher.HashPassword(user, password);
            return hashedPassword;
        }
    }
}
