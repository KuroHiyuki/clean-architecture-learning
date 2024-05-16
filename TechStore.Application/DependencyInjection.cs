using Microsoft.Extensions.DependencyInjection;

namespace TechStore.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<IAuthenticationQueryService, AuthenthicationQueryService>();
            //services.AddScoped<IAuthenticationCommandService, AuthenthicationCommandService>();

            services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            return services;
        }
    }
}
