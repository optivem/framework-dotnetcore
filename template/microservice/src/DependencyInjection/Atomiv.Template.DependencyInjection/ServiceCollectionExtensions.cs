﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Atomiv.DependencyInjection.Core.Application;
using Atomiv.DependencyInjection.Core.Domain;
using Atomiv.DependencyInjection.Infrastructure.AspNetCore;
using Atomiv.DependencyInjection.Infrastructure.AutoMapper;
using Atomiv.DependencyInjection.Infrastructure.EntityFrameworkCore;
using Atomiv.DependencyInjection.Infrastructure.FluentValidation;
using Atomiv.DependencyInjection.Infrastructure.MediatR;
using Atomiv.DependencyInjection.Infrastructure.NewtonsoftJson;
using Atomiv.DependencyInjection.Infrastructure.System;
using Atomiv.Template.Infrastructure.Web.Authentication.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Common.Requests;

namespace Atomiv.Template.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            var moduleTypes = GetModuleTypes();
            var assemblies = moduleTypes.Select(e => e.Assembly).ToArray();

            AddCoreModules<RequestType>(services, assemblies);
            AddInfrastructureModules(services, configuration, assemblies);
        }

        private static List<Type> GetModuleTypes()
        {
            var coreModuleTypes = new List<Type>
            {
                typeof(Core.Application.Module),
                typeof(Core.Application.Commands.Module),
                typeof(Core.Application.Commands.Handlers.Module),
                typeof(Core.Domain.Module),
                typeof(Core.Application.Queries.Module),
            };

            var infrastructureModuleTypes = new List<Type>
            {
                typeof(Infrastructure.Commands.Authorization.Module),
                typeof(Infrastructure.Commands.Mapping.Module),
                typeof(Infrastructure.Commands.Validation.Module),
                typeof(Infrastructure.Domain.Identities.Module),
                typeof(Infrastructure.Domain.Persistence.Module),
                typeof(Infrastructure.Domain.Repositories.Module),
                typeof(Infrastructure.Domain.Services.Module),
                typeof(Infrastructure.Queries.Authorization.Module),
                typeof(Infrastructure.Queries.Handlers.Module),
                typeof(Infrastructure.Queries.Validation.Module),
                typeof(Infrastructure.Web.Authentication.Module),
            };

            var moduleTypes = new List<Type>();
            moduleTypes.AddRange(coreModuleTypes);
            moduleTypes.AddRange(infrastructureModuleTypes);

            return moduleTypes;
        }

        private static void AddCoreModules<TRequestType>(this IServiceCollection services, Assembly[] assemblies)
            where TRequestType : Enum
        {
            services.AddApplicationCore<TRequestType>(assemblies);
            services.AddDomainCore(assemblies);
        }

        private static void AddInfrastructureModules(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
        {
            var connectionKey = ConfigurationKeys.DatabaseConnectionKey;
            var connection = configuration.GetConnectionString(connectionKey);

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(connection);
                options.EnableSensitiveDataLogging();
            });

            services.AddApplicationUserContext<ApplicationUser, 
                RequestType, 
                ApplicationUserSerializer, 
                IApplicationUserContext,
                ApplicationUserContext>();

            services.AddAutoMapper(assemblies);
            services.AddMediatR(assemblies);

            services.AddAspNetCoreInfrastructure(assemblies);
            services.AddEntityFrameworkCoreInfrastructure(assemblies);
            services.AddAutoMapperInfrastructure(assemblies);
            services.AddFluentValidationInfrastructure(assemblies);
            services.AddMediatRInfrastructure(assemblies);
            services.AddNewtonsoftJsonInfrastructure(assemblies);
            services.AddSystemInfrastructure(assemblies);
        }
    }
}