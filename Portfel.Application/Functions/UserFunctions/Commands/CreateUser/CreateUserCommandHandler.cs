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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.AddAsync(new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,

            });
            user.EncryptedPassword = GetHashedPassword(user, request.Password);
            return user;
        }
        private string GetHashedPassword(User user, string password)
        {
            var hashedPassword = _passwordHasher.HashPassword(user, password);
            return hashedPassword;
        }
    }
}
