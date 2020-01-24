using CopaFilmes.Application.Interface;
using CopaFilmes.Application.Service;
using CopaFilmes.Domain.Interface;
using CopaFilmes.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CopaFilmes.Infrastructure.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            var types = new List<Type>();
            types.AddRange(GetServiceTypes());
            types.AddRange(GetAppServiceTypes());

            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient(typeof(IAppServiceBase<>), typeof(AppServiceBase<,>));

            foreach (var type in types)
                services.AddTransient(type.GetInterface($"I{type.Name}"), type);

            return services;
        }

        private static IList<Type> GetServiceTypes() =>
            Assembly
                .GetAssembly(typeof(ServiceBase<>))
                .GetTypes()
                .Where(type =>
                    type.Namespace != null &&
                    type.Namespace.Equals(typeof(ServiceBase<>).Namespace) &&
                    type.IsClass && !type.Name.Contains("Base") &&
                    !type.Name.Contains("<"))
                .ToList();

        private static IList<Type> GetAppServiceTypes() =>
             Assembly
                .GetAssembly(typeof(AppServiceBase<,>))
                .GetTypes()
                .Where(type =>
                    type.Namespace != null &&
                    type.Namespace.Equals(typeof(AppServiceBase<,>).Namespace) &&
                    type.IsClass && !type.Name.Contains("Base") &&
                    !type.Name.Contains("<"))
                .ToList();
    }
}
