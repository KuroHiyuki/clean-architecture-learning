using Mapster;
using TechStore.Application.Authentication.Login.Queries;
using TechStore.Application.Authentication.Register.Commands;
using TechStore.Application.Services.Authentication;
using TechStore.Presentation.Authentication;

namespace TechStore.API.Common
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
