using Microsoft.AspNetCore.Mvc.Infrastructure;
using TechStore.API.Common;
using TechStore.API.Error;

namespace TechStore.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
            services.AddMappingConfig();

            return services;
        }
    }
}
