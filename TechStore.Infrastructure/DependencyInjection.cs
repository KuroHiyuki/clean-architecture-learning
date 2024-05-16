using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using TechStore.Application.Common.Interfaces.Authentication;
using TechStore.Application.Common.Interfaces.DateProvider;
using TechStore.Infrastructure.Authentication;
using TechStore.Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using TechStore.Application.Common.Interfaces.Persistence;
using TechStore.Infrastructure.Persistence;

namespace TechStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JwtSetting>(configuration.GetSection(JwtSetting.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider,DateTimProvider>();

            services.AddScoped<IUserRepository, UserRepository>();    
            return services;
        }
    }
}
