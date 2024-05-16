﻿using Mapster;
using MapsterMapper;
using System.Reflection;

namespace TechStore.API.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappingConfig(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper> ();
            return services;
        }
    }
}
