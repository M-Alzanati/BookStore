using System.Collections.Generic;
using System.Reflection;
using Autofac;
using BookStore.Core;
using BookStore.Infrastructure.Data;
using BookStore.SharedKernel.Interfaces;
using BookStore.Infrastructure.Services;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BookStore.Infrastructure
{
    public class InfrastructureModule : Autofac.Module
    {
        private List<Assembly> _assemblies = new List<Assembly>();

        public InfrastructureModule(Assembly callingAssembly = null)
        {
            var coreAssembly = Assembly.GetAssembly(typeof(DatabasePopulator));
            var infrastructureAssembly = Assembly.GetAssembly(typeof(EfRepository));

            _assemblies.Add(coreAssembly);
            _assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(_assemblies.ToArray())
                .AsImplementedInterfaces();

            builder.RegisterType<EfRepository>().As<IRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<QueryStringTenantIdentificationService>().As<ITenantIdentificationService<HttpContext>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TenantService>().As<ITenantService>()
                .InstancePerLifetimeScope();
        }
    }
}