using ErrorOr;
using MediatR;
using TechStore.Application.Common.Interfaces.Authentication;
using TechStore.Application.Common.Interfaces.Persistence;
using TechStore.Application.Services.Authentication;
using TechStore.Application.Services.Authentication.Commands;
using TechStore.Application.Services.Authentication.Queries;
using TechStore.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TechStore.Domain.Errors;

namespace TechStore.Application.Authentication.Register.Commands
{
    internal class RegisterCommandHandler(
        IJwtTokenGenerator _jwtTokenGenerator, 
        IUserRepository _userRepository) : IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
    {
        //private readonly IJwtTokenGenerator _jwtTokenGenerator;
        //private readonly IUserRepository _userRepository;

        //public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        //{
        //    _jwtTokenGenerator = jwtTokenGenerator;
        //    _userRepository = userRepository;
        //}
        public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            if (_userRepository.GetByEmail(command.Email) is not null)
            {
                return Errors.User.EmailExists;
            }
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthResult(user, token);
        }
    }
}
