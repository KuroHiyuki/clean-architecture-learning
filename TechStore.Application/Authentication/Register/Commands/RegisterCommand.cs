using ErrorOr;
using MediatR;
using TechStore.Application.Services.Authentication;

namespace TechStore.Application.Authentication.Register.Commands
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthResult>>;
}
