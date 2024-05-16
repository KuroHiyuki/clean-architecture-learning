using ErrorOr;
using MediatR;
using TechStore.Domain.Errors;
using TechStore.Application.Common.Interfaces.Authentication;
using TechStore.Application.Common.Interfaces.Persistence;
using TechStore.Application.Services.Authentication;
using TechStore.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TechStore.Application.Authentication.Login.Queries
{
    public class LoginQueryHandler(
        IJwtTokenGenerator _jwtTokenGenerator, 
        IUserRepository _userRepository) : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
    {
        //private readonly IJwtTokenGenerator _jwtTokenGenerator;
        //private readonly IUserRepository _userRepository;

        //public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        //{
        //    _jwtTokenGenerator = jwtTokenGenerator;
        //    _userRepository = userRepository;
        //}
        public async Task<ErrorOr<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_userRepository.GetByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthResult(user, token);
        }
    }
}
