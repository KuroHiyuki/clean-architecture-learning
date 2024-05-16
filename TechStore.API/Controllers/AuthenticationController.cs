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
using MapsterMapper;

namespace TechStore.API.Controllers
{
    [Route("auth/[controller]")]
    public class AuthenticationController : APIController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator,IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthResult> authResult = await _mediator.Send(command);
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthResult> authResult = await _mediator.Send(query);
            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode:StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }
    }
}
