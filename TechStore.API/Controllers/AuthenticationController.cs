using TechStore.Presentation.Authentication;
using Microsoft.AspNetCore.Mvc;
using TechStore.Application.Services.Authentication;
using ErrorOr;
using TechStore.Domain.Errors;
using TechStore.Application.Services.Authentication.Commands;
using TechStore.Application.Services.Authentication.Queries;
using MediatR;
using TechStore.Application.Authentication.Register.Commands;
using TechStore.Application.Authentication.Login.Queries;

namespace TechStore.API.Controllers
{
    [Route("auth/[controller]")]
    public class AuthenticationController : APIController
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName,
                request.LastName,
                request.Email,
                request.Password);
            ErrorOr<AuthResult> authResult = await _mediator.Send(command);
            return authResult.Match(
                authResult => Ok(MapAuthResults(authResult)),
                errors => Problem(errors));
        }

        private static AuthenticationResponse MapAuthResults(AuthResult authResult)
        {
            return new AuthenticationResponse(
                    authResult.User.Id,
                    authResult.User.FirstName!,
                    authResult.User.LastName!,
                    authResult.User.Email!,
                    authResult.Token
                    );
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);

            ErrorOr<AuthResult> authResult = await _mediator.Send(query);
            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode:StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }
            return authResult.Match(
                authResult => Ok(MapAuthResults(authResult)),
                errors => Problem(errors));
        }
    }
}
