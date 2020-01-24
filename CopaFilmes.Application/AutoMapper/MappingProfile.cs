using AutoMapper;
using CopaFilmes.Application.Model;
using CopaFilmes.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CopaFilmes.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var assemblyName = typeof(ModelBase).Assembly.GetName().Name;
            foreach (var type in GetEntityTypes())
            {
                var typeName = $"{typeof(ModelBase).Namespace}.{type.Name}Model";
                CreateMap(Type.GetType($"{typeName}, {assemblyName}"), type).ReverseMap();
            }
        }

        private static IEnumerable<Type> GetEntityTypes() =>
            Assembly
                .GetAssembly(typeof(EntityBase))
                .GetTypes()
                .Where(type =>
                    type.Namespace != null &&
                    type.Namespace.Equals(typeof(EntityBase).Namespace) &&
                    type.IsClass &&
                    !type.Name.Contains("Base") &&
                    !type.Name.Contains("<"));
    }
}