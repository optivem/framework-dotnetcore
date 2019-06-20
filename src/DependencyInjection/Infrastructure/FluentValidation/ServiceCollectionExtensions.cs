﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Core.Application;
using Optivem.Infrastructure.FluentValidation;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Optivem.DependencyInjection.Infrastructure.FluentValidation
{
    public static class ServiceCollectionExtensions
    {
        private static Type ValidatorType = typeof(IValidator<>);

        public static IServiceCollection AddFluentValidationInfrastructure(this IServiceCollection services, params Assembly[] assemblies)
        {
            assemblies = assemblies.GetCheckedAssemblies(AssemblyNameSuffixes.Infrastructure.FluentValidation);

            services.AddScoped(typeof(IRequestValidationHandler<>), typeof(RequestValidationHandler<>));
            services.AddScoped(typeof(IRequestValidator<>), typeof(FluentValidationRequestValidator<>));

            var types = assemblies.GetTypes();
            services.AddValidators(types);

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services, IEnumerable<Type> types)
        {
            var implementationTypes = types.GetConcreteImplementationsOfGenericInterface(ValidatorType);
            services.AddScopedOpenType(ValidatorType, implementationTypes);

            return services;
        }
    }
}