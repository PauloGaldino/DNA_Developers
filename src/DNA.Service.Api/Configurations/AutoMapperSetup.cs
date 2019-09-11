using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using DNA.Application.AutoMapper;

namespace DNA.Service.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registrar mapeamentos automaticamente funciona apenas se 
            // as classes Automapper Profile estão no projeto ASP.NET
            AutoMapperConfig.RegisterMappings();
        }
    }
}