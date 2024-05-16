using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechStore.Application.Common.Interfaces.Authentication;
using TechStore.Application.Common.Interfaces.DateProvider;
using TechStore.Application.Common.Interfaces.Persistence;
using TechStore.Infrastructure.Authentication;
using TechStore.Infrastructure.Persistence;
using TechStore.Infrastructure.Service;

namespace TechStore.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddAuthService(configuration);

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
        public static IServiceCollection AddAuthService(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {

            var JwtSetting = new JwtSetting();
            configuration.Bind(JwtSetting.SectionName, JwtSetting);
            services.AddSingleton(Options.Create(JwtSetting));

            //services.Configure<JwtSetting>(configuration.GetSection(JwtSetting.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimProvider>();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = JwtSetting.Audience,
                    ValidIssuer = JwtSetting.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(JwtSetting.Secret!))
                };
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsync("Unauthurized");
                    }
                };
            });
            services.AddAuthorization();
            return services;
        }
    }
}
