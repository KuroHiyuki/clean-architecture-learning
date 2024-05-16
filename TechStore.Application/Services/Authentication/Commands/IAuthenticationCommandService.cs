using ErrorOr;

namespace TechStore.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        //ErrorOr<AuthResult> Login(string email, string password);
        ErrorOr<AuthResult> Register(string FirstName, string LastName, string email, string password);
    }
}
