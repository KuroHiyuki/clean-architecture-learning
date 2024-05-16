using ErrorOr;
using MediatR;
using TechStore.Application.Services.Authentication;

namespace TechStore.Application.Authentication.Login.Queries
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthResult>>;
}
