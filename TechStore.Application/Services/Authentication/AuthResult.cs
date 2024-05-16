using TechStore.Domain.Entities;

namespace TechStore.Application.Services.Authentication
{
    public record AuthResult(
        User User,
        string Token
        );
}
