using ErrorOr;
using System.Reflection.Metadata.Ecma335;
using TechStore.Application.Common.Errors;
using TechStore.Application.Common.Interfaces.Authentication;
using TechStore.Application.Common.Interfaces.Persistence;
using TechStore.Domain.Entities;
using TechStore.Domain.Errors;

namespace TechStore.Application.Services.Authentication.Commands
{
    public class AuthenthicationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenthicationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthResult> Register(string FirstName, string LastName, string email, string password)
        {
            if (_userRepository.GetByEmail(email) is not null)
            {
                return Errors.User.EmailExists;
            }
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName,
                Email = email,
                Password = password
            };

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthResult(user, token);
        }
    }
}
